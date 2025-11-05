# TpsGame
## Giriş
Bu proje, **Unity oyun motoru** kullanılarak geliştirilen **Third Person Shooter (TPS)** türünde zombi karakterleri içeren bir oyundur.
Amaç, her level’da bulunan tüm zombileri yok ederek bir sonraki levele geçmek ve hayatta kalmaktır. Proje kapsamında, **Finite State Machine (FSM)** tabanlı bir yapay zekâ sistemi, **NavMesh Agent** ile yol bulma algoritması, **silah mekanikleri, reload sistemi, can ve mermi göstergeleri, pause menüsü ve level geçiş sistemi** geliştirilmiştir.
Tüm oyun mekanikleri düşük **low-poly** modeller ve sade grafiklerle tasarlanmıştır.

---
## Oyun Mekanikleri
| **Özellik**                   | **Açıklama**                                                                                                                       |
| ----------------------------- | ---------------------------------------------------------------------------------------------------------------------------------- |
| **TPS Kamera**                | Kamera, karakterin arkasında ve biraz yukarısında konumlanmıştır.                                                                  |
| **Ateş Etme ve Nişan Alma**   | Fare sol tık ile ateş edilir. Karakterin hedef alması TPS bakış açısına uygundur. Mermi sıfırlandığında “Game Over” ekranı açılır. |
| **Reload Sistemi**            | R tuşuna basarak silah yeniden doldurulabilir. Mermi sayısı ekranda gösterilir.                                                    |
| **Zombi FSM AI**              | Zombiler üç ana durumda çalışır: Idle → Chase → Attack.                                                                            |
| **Yol Bulma (Pathfinding)**   | Unity NavMesh Agent ile zombiler oyuncuya en kısa yoldan ulaşır.                                                                   |
| **Can Sistemi**               | Oyuncunun kalan canı ekranda gösterilir. Can sıfırlandığında “Game Over” ekranı açılır.                                            |
| **Kalan Zombi Sayısı**        | Level’daki canlı zombi sayısı ekranda gösterilir. Tüm zombiler öldüğünde bir sonraki levele geçilir.                               |
| **Pause / ESC Menüsü**        | ESC tuşu ile oyun durur. Oyuncu ESC ile oyuna devam edebilir ya da “Çıkış” seçeneği ile ana menüye dönebilir.                      |
| **Başlangıç ve Çıkış Ekranı** | Oyun açıldığında “Başla” ve “Çıkış” butonları olan ana menü karşılar.                                                              |

---
## Level-Sahne Yapısı
| **LEVEL** | **TEMA**      | **ZORLUK** | **ZOMBİ SAYISI** |
| --------- | ------------- | ---------- | ---------------- |
| **1**     | Şehir (Küçük) | Kolay      | 6                |
| **2**     | Şehir (Büyük) | Orta       | 11               |
| **3**     | Labirent      | Zor        | 19               |

---

## Literatür Taraması ve Benzer Çalışmalar

* https://github.com/chonkgames/Simple-Character-Controller-in-Unity
* https://discussions.unity.com/t/why-is-there-no-way-to-hide-the-mouse-cursor-when-entering-play-mode/918105/6
* https://discussions.unity.com/t/how-to-rotate-my-camera/164349/3
* https://github.com/Maraakis/ChristinaCreatesGames
* https://discussions.unity.com/t/using-old-and-new-input-system-at-the-same-time/851694/8
* https://www.youtube.com/watch?v=4HpC--2iowE

**Karşılaştırma**: Projemizin literatürdeki diğer oyunlardan birçok farkı bulunmaktadır. Örneğin Resident Evil serisi gibi oyunları ele alalım, bu tarz oyunlardan bizim oyunumuzun en büyük farkı kesinlikle grafik ve oyun mekanikleridir. Biz oyunumuzda low-poly grafik kalitesi kullanırken Resident Evil gibi oyunlarda high-poly kalite kullanılıyor. Bu kullanım oyun deneyimini iyileştirirken aynı zamanda oyunun yükünü de arttırmakta. Bu sebepten bizim oyunumuz daha çok oyun mekaniklerini kavrama yönünde eğitici bir oyun diyebiliriz. Biz basit bir FSM kullanırken büyük ölçekli oyunlar genelde behavior tree kullanıyor. Ayrıca biz oyunumuzda level sayısını düşük tuttuk büyük ölçekli oyunlara göre.

## Kullanılan Teknolojiler
* Unity Engine
* C# Programlama Dili
* NavMesh Agent (Pathfinding)
* Finite State Machine (FSM)
* Canvas UI (Text, Image, Button)
* Event System (Button Click, Input)
* Scene Management (Level geçişleri)

## Karşılaşılan Zorluklar ve Çözümler
| **ZORLUK**                                                                                              | **ÇÖZÜM**                                                                                                       |
| ------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| Eski ve yeni input sistemleri farkları                                                                  | **Active Input Handling Both** yapılarak iki sistem birden etkinleştirildi.                        |
| Ateş etme animasyonu eklendikten sonra karakterin sola dönük pozisyonda kalması                         | Animasyon klibi içinde karakterin yönü hafif sağa kaydırılarak karakter pozisyonu ekranda ortalandı.                           |
| “Merminiz Tükendi” ekranı geldikten sonra karakter ölünce ikinci kez “Öldünüz” ekranı açılması          | Game Over ekranı açıldığında **Time.timeScale = 0f** yapılarak oyun durduruldu ve tekrar açılması engellendi. |
| GitHub’a büyük boyutlu dosya yüklenememesi                                                              | **Git LFS (Large File Storage)** kullanılarak büyük dosyaların yüklenmesi sağlandı.                             |
| R ile şarjör değiştikten sonra cephanenin eksiye düşmesi ve bu sebepten Game Over ekranının gelmemesi   | Şarjör değiştirme kısmındaki koda bir  if–else kontrolü yapısı koyularak sorun çözüldü.                   |
| Mermilerin duvardan geçmesi ve zombilere hasar vermesi                                                       | **Layer Mask** özelliği kullanılarak hem NPC layerı hem de default layerı dahil edilerek çözüldü               |

## Projenin Katkıları
* Unity sahne yönetimi ve UI tasarımı pratiği
* Sıfırdan oyun geliştirmenin temel aşamalarını öğrenme
* Takım içi görev paylaşımı 
* GitHub sürüm kontrolü deneyimi
* Literatür taraması ve araştırma yapma becerisi
* Örnek proje inceleme ve uygulama
* Sahne ve map tasarımı yapabilme
* Oyun mekaniklerini kodlama ve test etme becerisi

## Oynayış Talimatı
| **TUŞ**             | **İŞLEV**                         |
| ------------------- | --------------------------------- |
| **W / A / S / D**   | Karakteri hareket ettirme        |
| **Mouse Sol Click** | Ateş etme                        |
| **R**               | Mermiyi değiştirme         |
| **Esc**             | Pause menüsünü açma ve kapama |

## Sistem Şeması
[ OYUN BAŞLANGICI ]

│

▼

[ Ana Menü Ekranı ]

├─ “Oyuna Başla”

└─ “Çıkış”

│

▼

[ Level 1 Başlatıldı ]

├─ Player Spawn

├─ NPC (Zombiler) Spawn

└─ UI aktif (Can, Mermi, Zombi Sayısı)

│

▼

[ Player Controller ]

├─ Hareket (WASD)

├─ Ateş Etme (Mouse 0)

├─ Mermi Yenileme (R)

└─ Can Azalırsa → Health Bar Güncellenir

│

▼

[ NPC Controller (Zombie AI) ]

├─ FSM: Idle → Chase → Attack

├─ NavMesh ile Oyuncuya Yaklaşır

└─ Saldırı sonucu oyuncunun canı azalır

│

▼

[ Çatışma ve Oyun İçi Kontroller ]

├─ Mermi Sayısı 0 → “Merminiz Tükendi” Game Over

├─ Can 0 → “Öldünüz” Game Over

└─ Tüm Zombiler Öldü → Level Tamamlandı

│

▼

[ LevelManager ]

├─ Sonraki Level’a Geç

└─ Verileri Sıfırla

│

▼

[ Pause Menü (ESC) ]

├─ Oyun Durur

└─ Ana Menüye Dön / Devam Et

│

▼

[ Oyun Bitişi ]

├─ Game Over

└─ Tüm Level’lar Tamamlandı → Ana Menüye Dön

## Blok Diyagramı

---
## Geliştirenler
* Emre Beraat Samuk- [emresamuk]
* Gülnihal Eruslu- [gulni-hal]
* Metehan Yüksek- [metehan-41]  








