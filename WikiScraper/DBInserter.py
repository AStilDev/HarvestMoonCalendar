import sqlite3

db = sqlite3.connect('C:\\Users\Alisha\Desktop\Programming Projects\WebScraper\WikiScraper\harvestmoondb.db')

cursor = db.cursor()

id = 1
name = 'Elli'
birthday = 'Spring 16'

cursor.execute('''INSERT INTO characters(gameid, name, birthday)
                  VALUES(?,?,?)''', (id, name, birthday))
print('Entry added')
db.commit()

db.close()
