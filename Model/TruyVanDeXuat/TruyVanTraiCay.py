import unicodedata
import mysql.connector
from flask import Flask, jsonify, request
from flask_cors import CORS

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
    database.append({"mon" : Ten, "chuabenh" : danh_sach})

app = Flask(__name__)
CORS(app)
@app.route('/data',methods=["POST"])

def nhandulieu():
    data = request.get_json()
    if not data:
        print("skibidi")
        return jsonify({"error": "No data provided"}), 400
    try:
        duLieuTraVe = de_xuat_monan(cau_hoi=data['text'])
        return jsonify({"message": duLieuTraVe}), 201
    except mysql.connector.Error as err:
        return jsonify({"error": str(err)}), 500

def de_xuat_monan(cau_hoi):
    cau_hoi = bo_dau(cau_hoi.lower())
    tu_khoa = cau_hoi.split()

    ket_qua = []
    for item in database:
        diem = 0
        for keyword in item["chuabenh"]:
            keyword_norm = bo_dau(keyword.lower())
            for tu in tu_khoa:
                if tu in keyword_norm:
                    diem += 1
        ket_qua.append((item["mon"], diem))

    ket_qua.sort(key=lambda x: x[1], reverse=True)
    if ket_qua[0][1] == 0:
        return "Xin lỗi, tôi chưa tìm được món ăn phù hợp với triệu chứng của bạn."
    return f"Bạn nên thử món: {ket_qua[0][0]}"
def bo_dau(text):
    text = unicodedata.normalize('NFD', text)
    return ''.join(ch for ch in text if unicodedata.category(ch) != "Mn")
if __name__ == "__main__":
    app.run(port=8000, debug=True)
