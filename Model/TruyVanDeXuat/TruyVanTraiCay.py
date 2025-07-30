import unicodedata
import mysql.connector

mysql = mysql.connector.connect(
    host = "localhost",
    user = "root",
    password = "123456",
    database = "traicay"
)

mycursor = mysql.cursor()
mycursor.execute("Select tentraicay, chuabenh from thongtintraicay")
result = mycursor.fetchall()
database = []
for Ten,ChuaBenh in result:
    danh_sach = [b.strip() for b in ChuaBenh.split(',')]
    database.append({"mon" : Ten, "chuabenh" : ChuaBenh})

def bo_dau(text):
    text = unicodedata.normalize('NFD', text)
    return ''.join(ch for ch in text if unicodedata.category(ch) != "Mn")
