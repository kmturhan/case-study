# Kurulum
![image](https://github.com/kmturhan/case-study/assets/22748839/757754d3-bf3c-46a6-ab76-9f367223f121)

CaseStudy.API seçiliyken "dotnet run" komutuyla proje çalıştırılabilir. 

![image](https://github.com/kmturhan/case-study/assets/22748839/6412cf35-1e4d-44c8-8420-a086ed997134)

"Now listening on: http://localhost:5174" bu mesaj alındığında tarayıcıdan http://localhost:5174/swagger/index.html bu adrese gidebilirsiniz.

# Örnekler

Koddaki açıklamalarımı aşağıdaki iki adrese uzunca yazmaya çalıştım inceleyebilirsiniz. 

https://github.com/kmturhan/case-study/tree/main/CaseStudy.Core/Repository/Concrete

https://github.com/kmturhan/case-study/blob/main/CaseStudy.API/Controllers/OcrController.cs


İlk önce kod üretmemiz gerekiyor.

"**/api/Product/CodeGenerates**" endpoint'ine istek yapmamız gerekiyor.
Kodlar aşağıdaki gibi unique olarak üretildi. İstersek tekrar çalıştırabiliriz. Yenileri listeye eklenecektir.

![image](https://github.com/kmturhan/case-study/assets/22748839/080dfc2a-3fcf-45cd-97f3-b08c2ad5d58f)

Ürettiğimiz kodlardan birini kullanmak için "**/api/Product/UseCode**" endpointini kullanarak "**IsValid**" alanını güncelleyebiliriz.

![image](https://github.com/kmturhan/case-study/assets/22748839/a4d11f33-2bb8-40b3-8af1-f20fe631f415)

Tüm kod listesinin güncel durumunu görebilmek için "**api/Product/GetList**" endpointini kullanıyoruz.

![image](https://github.com/kmturhan/case-study/assets/22748839/9f496157-35f1-42a3-b5c5-8cb415bda427)

Birden fazla kodu aynı anda kullanmak için "**api/Product/UseCodes**" enpointini kullanıyoruz.

![image](https://github.com/kmturhan/case-study/assets/22748839/954a5db4-506f-4e32-9edb-4e59a00563b8)

Kod üretirken charseti kullanıcı tanımlayacak ise "**api/Product/CodeGeneratesWithCharSet**" endpointini kullanabiliriz.

Uygulama kapanana kadar kod listesi hafızada duracak ve yeni üretilen kodlar eklenmeye devam edecektir.

![image](https://github.com/kmturhan/case-study/assets/22748839/206c9350-1f14-4df0-9ebc-a6aa69468b22)

# OCR Kullanımı

CaseStudy.API projesinde "DummyFile" klasörünün içindeki response.json dosyası hedef gösterilmesi gerekiyor.

![image](https://github.com/kmturhan/case-study/assets/22748839/31ef5810-7f79-4fa2-9871-4293dedbd6e6)

"**/api/Ocr/JsonParse**" endpointi çalıştırılarak kullanılabilir. Üretilen çıktıyı görselin altında iletiyorum.

![image](https://github.com/kmturhan/case-study/assets/22748839/5c2f62f4-6b7a-428e-aca6-57878d731b66)


# OCR Çıktısı

```[
  {
    "line": 1,
    "text": "TEŞEKKÜRLER"
  },
  {
    "line": 2,
    "text": "GUNEYDOĞU TEKS. GIDA INS SAN. LTD.STI."
  },
  {
    "line": 3,
    "text": "ORNEKTEPE MAH.ETIBANK CAD.SARAY APT."
  },
  {
    "line": 4,
    "text": "N:43-1 BEYOĞLU/ISTANBUL"
  },
  {
    "line": 5,
    "text": "GÜNEŞLİ V.D. 4350078928 V. NO."
  },
  {
    "line": 6,
    "text": "TARIH : 26.08.2020"
  },
  {
    "line": 7,
    "text": "SAAT : 15:27"
  },
  {
    "line": 8,
    "text": "FİŞ NO : 0082"
  },
  {
    "line": 9,
    "text": "54491250"
  },
  {
    "line": 10,
    "text": "2 ADx 2,75"
  },
  {
    "line": 11,
    "text": "CC.COCA COLA CAM 200 08 *5,50"
  },
  {
    "line": 12,
    "text": "2701084"
  },
  {
    "line": 13,
    "text": "1,566 KGx 1,99"
  },
  {
    "line": 14,
    "text": "MANAV DOMATES PETEME *3,32"
  },
  {
    "line": 15,
    "text": "2701076"
  },
  {
    "line": 16,
    "text": "0,358 KGx 4,99"
  },
  {
    "line": 17,
    "text": "MANAV BIBER CARLISTO 08 *1,79"
  },
  {
    "line": 18,
    "text": "EKMEK CIFTLI 01 *1,25"
  },
  {
    "line": 19,
    "text": "TOPKDV *0,80"
  },
  {
    "line": 20,
    "text": "TOPLAM *11,86"
  },
  {
    "line": 21,
    "text": "NAKİT *20,00"
  },
  {
    "line": 22,
    "text": "KDV KDV TUTARI KDV'LI TOPLAM"
  },
  {
    "line": 23,
    "text": "01 *0,01 *1,25"
  },
  {
    "line": 24,
    "text": "08 *0,79 *10,61"
  },
  {
    "line": 25,
    "text": "KASİYER : SUPERVISOR"
  },
  {
    "line": 26,
    "text": "00 0001/020/000084/1//82/"
  },
  {
    "line": 27,
    "text": "PARA USTÜ *8,14"
  },
  {
    "line": 28,
    "text": "KASİYER: 1"
  },
  {
    "line": 29,
    "text": "2 NO:1330 EKÜ NO:0001"
  },
  {
    "line": 30,
    "text": "MF YAB 15017876"
  }
]
```
