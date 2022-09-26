# PayCore & Patika .Net Bootcamp - Final Projesi
***Proje Konusu*** : Örnek bir 2.el alışveris sitesi Backend yapısı; kullanıcı sisteme kayıt olur ve giriş yapar, ürünlerini ilana ekleyebilir ve kendi ürünlerine gelen teklifleri görüntüleyebilir, ilanda olan diğer kullanıcıların ürünlerini listeleyebilir ve onlara teklif verebilir.Sistemdeki kategoriler üzerinde sadece admin rolü değişiklik yapabilir ve admin kullanıcıları listeleyebilir.
### Proje Kullanılanlar; 
* **ASP.NET 6** 
* **Onion Architecture**
* **NHİBERNATE**
* **Repository Pattern**
* **Fluent Validation**
* **CQRS yapısı ve Mediatr kütüphanesi**
* **Jwt Token ile giriş yapma ve rolleme işlemleri**
* **PosgreSql**
* **Mapster**
* **SeriLogger**
* **Cache**
 
## Projenin Genel Endpoint yapısı
![image](https://user-images.githubusercontent.com/99317183/191699969-451895c7-f388-46f2-8240-f40ade606318.png)

## Örnek Senaryo
- **Kullanıcı sisteme kayıt olur**

![image](https://user-images.githubusercontent.com/99317183/191675784-899c805f-59d7-43de-bd15-5177f9170ac5.png)

- **Kullanıcının girdiği şifre gerekli validasyonlara uymadığı için hata alır**

![image](https://user-images.githubusercontent.com/99317183/191675901-4e02e158-91bb-4d38-901a-5a946b723971.png)

- **Geçerli şifre girilince kayıt olur ve sisteme bilgileri ile giriş yapar**

![image](https://user-images.githubusercontent.com/99317183/191676223-e54e99e4-4ff2-4c65-90e1-ba645c31797a.png)

- **Eğer bilgileri doğru ise sistemden geçerli token'ı alır**

![image](https://user-images.githubusercontent.com/99317183/191676486-edab7360-d764-49b6-919e-03b492d1d264.png)

- **Kategorileri Listeler**

![image](https://user-images.githubusercontent.com/99317183/191678159-77d376ad-4121-4ef8-b036-fb8d3d184fd7.png)

- **Ürün Ekler**

![image](https://user-images.githubusercontent.com/99317183/191682489-0a1d7746-e50e-44e8-8538-29758b039378.png)

- **Ürününe gelen teklifleri görüntüler**

![image](https://user-images.githubusercontent.com/99317183/191683007-e1991b0f-73ea-4f9f-9ff9-9263bc87b634.png)

- **En yüksek Teklifi seçer ve kabul eder**

![image](https://user-images.githubusercontent.com/99317183/191684311-49b5e74f-5750-4faa-830f-5ee2333c0c76.png)

- **Teklif durumu kabul edildi olarak değişir ve ürün satıldı olarak işaretlenir**

![image](https://user-images.githubusercontent.com/99317183/191686809-b942699b-6e25-4263-ad79-fa4c1ab8385b.png)
![image](https://user-images.githubusercontent.com/99317183/191684627-77edfcdc-5d4b-4fa9-92ef-618e1798c807.png)


## Admin Senaryo

-**Kategori Ekler/Günceller**

![image](https://user-images.githubusercontent.com/99317183/191698122-2883d05c-8853-4136-935a-536090a8db5d.png)

-**Kullanıcıları Listeler(CacheResponse ile dönüş yapılır.)**

![image](https://user-images.githubusercontent.com/99317183/191700904-a5e4c547-a736-46ed-b838-c92091a5e604.png)




## Projeyi Çalıştırmak

### Ön Gereksinimler
* Visual Studio 2020+
* PostgreSql
* .Net 6.0

### Çalıştırılması
Local klasöre projeyi klonlamak için :
```
 git clone https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/FinalProject-Bedrhann
```
PosgreSql bağlantı yolunuzu aşagıdaki gibi kendi bilgisayarına göre giriniz.

 ![image](https://user-images.githubusercontent.com/99317183/191688309-1b5d2036-7ad4-4668-95e4-7b5859f7d3c9.png)

Log dosyasının dosya yolunu kendi bilgisayarınıza göre  aşağıdaki gibi düzeltiniz

![image](https://user-images.githubusercontent.com/99317183/191688626-ac0dfb2d-c9d1-4263-84b1-ba71100c99f0.png)

<br/>
-Projeyi derleyip çalıştırdığınızda gerekli veritabanı sisteminize kurulacak ve proje ayağa kalkacaktır.-
