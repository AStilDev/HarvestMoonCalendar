from bs4 import BeautifulSoup
import requests
import re
import sqlite3
from sqlite3 import Error

def main():
    db_file = 'C:\\Users\Alisha\Desktop\Programming_Projects\HarvestMoonCalendar\harvestmoondb.db' #'C:\\Users\Alisha\Desktop\Programming Projects\WebScraper\WikiScraper\harvestmoondb.db'
    baseurl = 'http://harvestmoon.wikia.com'
    url = 'http://harvestmoon.wikia.com/wiki/Category:Story_of_Seasons:_Friends_of_Mineral_Town_Characters'
    game_id = 2
    id = 34
    birthday = ""
    likes_dict = {
        "favorited" : "",
        "loved" : "",
        "liked" : "",
        "neutral" : "",
        "disliked" : "",
        "hated" : ""
    }
    matches = ["Special", "Loved", "Liked", "Hated", "Neutral", "Disliked", "\""]

    # connect to db
    db = create_connection(db_file)
    cursor = db.cursor()

    chara_urls = get_chara_urls(baseurl, url)

    # go into each link and grab each chara's name
    for chara_url in chara_urls:
        if '.png' not in chara_url:
            # dive in
            content = requests.get(chara_url).content
            # get soup
            soup = BeautifulSoup(content,'html.parser') # choose html parser
            chara_name = soup.find('h2', class_='pi-item')

            birthday_soup = soup.find('div', class_='pi-data-value pi-font')
            if birthday_soup is not None:
                birthday_cake = birthday_soup.text
                find_day = re.search('\w+\s*\w+', birthday_cake) # only want first result though
                birthday = find_day.group(0)

            # table of likes
            data = []
            table = soup.find('table', attrs={'class':'article-table'})

            if table is not None:
                rows = table.find_all('tr')
                for row in rows:
                    cols = row.find_all('td')
                    cols = [ele.text.strip() for ele in cols]
                    data.append([ele for ele in cols if ele]) # Get rid of empty values

                # todo don't print if null
                if chara_name is not None:
                    name = chara_name.text
                    print(name)

                if birthday is not None:
                    print(birthday)

                if data is not None:
                    count = 0
                    flag = 'false'
                    #if "Vivant" in chara_name:
                    #   likes_dict["favorited"] = ""
                    #  likes_dict["loved"] = ""
                    # likes_dict["liked"] = ""
                    #likes_dict["hated"] = ""
                    #continue
                    for row in data:
                        if len(row) is not 0:
                            if not any(x in row[0] for x in matches):
                                if count is not 0:
                                    row[0] = row[0].replace("・", ", ")
                                    if len(data) is 12: #and flag is 'false': # includes favorited items (8)
                                        if count is 1:
                                            likes_dict["favorited"] = row[0]
                                            count -= 1
                                            flag = 'true'
                                        elif count is 2:
                                           likes_dict["loved"] = row[0]
                                        elif count is 4:
                                            likes_dict['liked'] = row[0]
                                        elif count is 10:
                                            likes_dict['hated'] = row[0]
                                    else:
                                        likes_dict["favorited"] = ""
                                        if count is 1:
                                            likes_dict["loved"] = row[0]
                                        elif count is 3:
                                            likes_dict['liked'] = row[0]
                                        elif count is 9:
                                            likes_dict['hated'] = row[0]
                            elif "\"" not in row[1]:
                                row[1] = row[1].replace("・", ", ")
                                likes_dict["favorited"] = ""
                                if count is 0:
                                    likes_dict["loved"] = row[1]
                                elif count is 1:
                                    likes_dict['liked'] = row[1]
                                elif count is 4:
                                    likes_dict['hated'] = row[1]
                            count += 1
                        else:
                            likes_dict["favorited"] = ""
                            likes_dict["loved"] = ""
                            likes_dict["liked"] = ""
                            likes_dict["hated"] = ""

                if chara_name is not None and birthday is not None and data is not None:
                    cursor.execute('''INSERT INTO characters(gameid, name, birthday, characterid, favorited, loved, liked, disliked)
                                        VALUES(?,?,?,?,?,?,?,?)''', (game_id, name, birthday, id, likes_dict["favorited"], likes_dict["loved"], likes_dict['liked'], likes_dict['hated']))
                    print('Entry added')
                    db.commit()
                    id += 1 # increment character id

    db.close()

def create_connection(db_file):
    try:
        db = sqlite3.connect(db_file)
        return db
    except Error as e:
        print(e)

    return None

def get_chara_urls(baseurl, url):
    # get contents from url
    content = requests.get(url).content
    # get soup
    soup = BeautifulSoup(content,'html.parser') # choose html parser

    # get all the links
    links = soup.findAll('a', text = re.compile(".*\(SoSFoMT\)")) #title CONTAINS (LoH)
    # store them
    chara_urls = [] 
    for link in links:
      chara_urls.append(baseurl + link.get('href')) # get text from <a>

    return chara_urls

def switch(argument, row, loved, liked, neutral, disliked, hated):
    if argument is 2:
        loved = row
    elif argument is 3:
        liked = row
    elif argument is 4:
        neutral = row
    elif argument is 5:
        disliked = row
    elif argument is 6:
        hated = row

if __name__ == '__main__':
    main()