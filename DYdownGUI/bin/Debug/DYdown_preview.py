from gettext import find
import time
import requests
import json
import re
import os
import sys
from urllib import parse

headers = {
    'User-Agent': "Mozilla/5.0 (iPhone; CPU iPhone OS 11_0 like Mac OS X) AppleWebKit/604.1.38 (KHTML, like Gecko) Version/11.0 Mobile/15A372 Safari/604.1"}


def cNurl(url, max_cursor):
    urlLst = list(parse.urlparse(url))  # listing the url
    qs = parse.parse_qs(urlLst[4])  # select the fourth element
    qs['max_cursor'] = max_cursor  # replace as new max_cursor
    urlLst[4] = parse.urlencode(qs, True)  # concatenate a new fourth element
    url_new = parse.urlunparse(urlLst)  # concatenate a new url
    return url_new


def save_vaddr(dict):
    fO = open('urls.txt', 'w', encoding='utf-8')
    for i in range(len(dict)):
        fO.write(str(dict[i])+'\r')
    fO.close()


def long_url_gen():
    url_r = re.findall(r'\/(?=[^\/]*$)(.+)',
                       str(requests.get(sys.argv[1]).url))
    url = 'https://www.iesdouyin.com/web/api/v2/aweme/post/?sec_uid=' + \
        str(url_r[0]) + \
        '&count=35&max_cursor=0&_signature=wEzUXgAAoovdht5Qs7UJEsBM1E'
    return url


def local_vaddr_load():
    fRd = open('urls.txt', encoding='utf-8')
    fLst = list(fRd)
    fRd.close()
    return fLst


def check_path_exist():
    path = './DY_videos/'
    if not os.path.exists(path):
        os.makedirs(path)
    return path


def fetch_vaddr(url):
    # get for essential data
    r = requests.get(url=url, headers=headers, stream=True)
    max_cursor = 0

    if not r.status_code == 200:
        print('[网络错误]\r')
    else:
        # parse into json
        json_data = json.loads(r.text)

        if not json_data['aweme_list'] == []:

            vaddr_dict = []
            # At least try one time for in case
            has_more = True

            while has_more:

                url_new = cNurl(url, max_cursor)
                r = requests.get(url=url_new, headers=headers, stream=True)
                json_data = json.loads(r.text)
                # if false then exit next while
                has_more = json_data['has_more']
                # storage next page cursor
                max_cursor = json_data['max_cursor']

                for i in range(len(json_data['aweme_list'])):
                    try:
                        vaddr = json_data['aweme_list'][i]['video']['play_addr_lowbr']['url_list'][0]
                    except:
                        vaddr = ''

                    vaddr_dict.append({
                        'title': json_data['aweme_list'][i]['desc'],
                        'vaddr': vaddr
                    })

            save_vaddr(vaddr_dict)
        else:
            print('[主页内容为空]')


def downloader_core(fLst, loopTimes, fIndex):

    for i in range(loopTimes):
        # specific the index
        if fIndex > -1:
            i = fIndex
        # vaddr for video address
        vaddr = re.search(r'\'(https.+)\'', fLst[i])

        if vaddr:
            # t for title
            try:
                T = re.findall(r'\'(.+?)\'', fLst[i])
                t = str(T[1]).strip('['']')

                wVc = r'[\?\*\/\\\|\.\:\>\<\n\r]'
                # replace special characters to ""
                path_1 = path + re.sub(wVc, '', t) + '.mp4'
                print(f'[视频即将保存在]:{path_1}')
            except:
                t = '无标题' + str(int(time.time()))
                path_1 = path + t + '.mp4'
                print(f'[视频即将保存在]:{path_1}')

            r = requests.get(url=vaddr.group(1), headers=headers, stream=True)
            # fetch videos binary data
            reponse_body_lenth = int(r.headers.get("Content-Length"))
            sys.stdout.write('[文件大小]:%0.2f MB\n' %
                             (reponse_body_lenth / 1024 / 1024))

            if os.path.isfile(path_1):
                print('[该视频已存在，跳过...]\r')
            else:
                with open(path_1, "wb") as xh:
                    write_all = 0
                    for chunk in r.iter_content(chunk_size=1000000):
                        write_all += xh.write(chunk)
                        sys.stdout.write('下载进度：%0.2f' %
                                         (100 * write_all / reponse_body_lenth)+'\r')
            time.sleep(1)


if __name__ == '__main__':

    # initialize storage folder
    path = check_path_exist()

    # load local url.txt
    try:
        fLst = local_vaddr_load()
    # else retrive from internet
    except:
        # long url generation
        url = long_url_gen()

        # fetch video addresses via request
        fetch_vaddr(url)

        fLst = local_vaddr_load()

    # start to roll
    if int(sys.argv[2]) == -1:  # download all (PS: -1 = read all)
        downloader_core(fLst, len(fLst), -1)
    elif int(sys.argv[2]) > -1 :   # if pointing to a specific address
        downloader_core(fLst, 1, int(sys.argv[2]))

