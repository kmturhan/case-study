# Kurulum
![image](https://github.com/kmturhan/case-study/assets/22748839/757754d3-bf3c-46a6-ab76-9f367223f121)

CaseStudy.API seçiliyken "dotnet run" komutuyla proje çalıştırılabilir. 

![image](https://github.com/kmturhan/case-study/assets/22748839/6412cf35-1e4d-44c8-8420-a086ed997134)

"Now listening on: http://localhost:5174" bu mesaj alındığında tarayıcıdan http://localhost:5174/swagger/index.html bu adrese gidebilirsiniz.

# Örnekler
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
