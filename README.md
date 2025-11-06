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


| SAYFA | İŞLEVİ |
|--------|---------|
| Main Menü | Başla ve Çıkış butonunu bulundurur. |
| Game Over (Öldünüz) | Oyuncunu canı bitince ekrana gelir, yeniden başla ve ana menüye dön butonu bulundurur. |
| Game Over (Merminiz Tükendi) | Oyuncunu mermisi bitince ekrana gelir, yeniden başla ve ana menüye dön butonu bulundurur. |
| Pause | Esc tuşuna basıldığında ekrana gelir, oyunu durdurur ve ana menüye dön butonu bulundurur. |
| Canvas | Can barı, Crosshair, mermi sayısı ve kalan zombi sayısını gösterir. |
| Level Geçiş | Oyuncu her bir level'ı tamamladığında ekrana gelir ve sonraki levele geçmeyi sağlar. |
| Kazandınız | Oyuncu son level'ı tamamladığında ekrana gelir. |


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
| Eski ve yeni input sistemleri farkları                                                                  | **Active Input Handling** both yapılarak iki sistem birden etkinleştirildi.                        |
| Ateş etme animasyonu eklendikten sonra karakterin sola dönük pozisyonda kalması                         | Animasyon klibi içinde karakterin yönü hafif sağa kaydırılarak karakter pozisyonu ekranda ortalandı.                           |
| “Merminiz Tükendi” ekranı geldikten sonra karakter ölünce ikinci kez “Öldünüz” ekranı açılması          | Game Over ekranı açıldığında **Time.timeScale = 0f** yapılarak oyun durduruldu ve tekrar açılması engellendi. |
| GitHub’a büyük boyutlu dosya yüklenememesi                                                              | **Git LFS (Large File Storage)** kullanılarak büyük dosyaların yüklenmesi sağlandı.                             |
| R ile şarjör değiştikten sonra cephanenin eksiye düşmesi ve bu sebepten Game Over ekranının gelmemesi   | Şarjör değiştirme kısmındaki koda bir  if–else kontrolü yapısı koyularak sorun çözüldü.                   |
| Mermilerin duvardan geçmesi ve zombilere hasar vermesi                                                       | **Layer Mask** özelliği kullanılarak hem NPC layer'ı hem de default layer'ı dahil edilerek çözüldü               |

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

[ Level Başlatıldı ]

├─ Player Spawn

├─ NPC (Zombiler) Spawn

└─ UI aktif (Can, Mermi, Zombi Sayısı)

│

▼

[ Player Controller ]

├─ Hareket (WASD)

├─ Ateş Etme (Mouse Sol Click)

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
[blokDiyagramı.drawio](https://github.com/user-attachments/files/23399065/blokDiyagrami.drawio)
<mxfile host="app.diagrams.net" agent="Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/141.0.0.0 Safari/537.36" version="28.2.9">
  <diagram name="Sayfa -1" id="bALXnrY3D4MwLLZRNmuc">
    <mxGraphModel dx="996" dy="3013" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="827" pageHeight="1169" math="0" shadow="0">
      <root>
        <mxCell id="0" />
        <mxCell id="1" parent="0" />
        <mxCell id="86CSyU7w3ejZ87KWMk9O-4" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;entryX=0.5;entryY=0;entryDx=0;entryDy=0;entryPerimeter=0;" parent="1" target="86CSyU7w3ejZ87KWMk9O-2" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="375" y="-1266" as="sourcePoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-1" value="Level Başlar" style="ellipse;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="326.5" y="-1331" width="97" height="70" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-6" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" parent="1" source="86CSyU7w3ejZ87KWMk9O-2" target="86CSyU7w3ejZ87KWMk9O-5" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-2" value="Oyuncu Hareket Eder&lt;div&gt;(W,A,S,D)&lt;/div&gt;" style="rounded=0;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="315" y="-1241" width="120" height="60" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-59" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" parent="1" source="86CSyU7w3ejZ87KWMk9O-5" target="86CSyU7w3ejZ87KWMk9O-57" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-5" value="Oyuncu Ateş Eder&lt;div&gt;(Fare Sol Click)&lt;/div&gt;" style="rounded=0;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="315" y="-1116" width="120" height="60" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-22" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" parent="1" source="86CSyU7w3ejZ87KWMk9O-7" target="86CSyU7w3ejZ87KWMk9O-16" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-50" style="edgeStyle=elbowEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;exitX=1;exitY=0.5;exitDx=0;exitDy=0;" parent="1" source="86CSyU7w3ejZ87KWMk9O-7" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="380" y="-1136" as="targetPoint" />
            <Array as="points">
              <mxPoint x="768" y="-966" />
              <mxPoint x="648" y="-976" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-7" value="Mermi Zombiye İsabet Etti mi?" style="rhombus;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="318.5" y="-801" width="113" height="120" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-19" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" parent="1" source="86CSyU7w3ejZ87KWMk9O-16" target="86CSyU7w3ejZ87KWMk9O-18" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-2" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" edge="1" parent="1" source="86CSyU7w3ejZ87KWMk9O-16" target="QPiGmSm-muWGbrL4p8YD-1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-16" value="Zombi Öldü mü?" style="rhombus;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="68" y="-796" width="120" height="110" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-21" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" parent="1" source="86CSyU7w3ejZ87KWMk9O-18" target="86CSyU7w3ejZ87KWMk9O-20" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-18" value="Zombi Sayısı Azalt" style="rounded=0;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="68" y="-561" width="120" height="60" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-36" style="edgeStyle=elbowEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" parent="1" source="86CSyU7w3ejZ87KWMk9O-20" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="428" y="-1226" as="targetPoint" />
            <Array as="points">
              <mxPoint x="788" y="-946" />
              <mxPoint x="718" y="-1176" />
              <mxPoint x="718" y="-936" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-40" value="" style="edgeStyle=none;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" parent="1" source="86CSyU7w3ejZ87KWMk9O-20" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="302.9999999999998" y="-336" as="targetPoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-20" value="Zombi Sayısı = 0 ?" style="rhombus;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="238" y="-586" width="130" height="110" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-23" value="Evet" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="228" y="-775" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-25" value="Hayır" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="448" y="-775" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-31" value="Evet" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="248" y="-446" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-37" value="Hayır" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="388" y="-566" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-45" style="edgeStyle=elbowEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;exitX=0;exitY=0.5;exitDx=0;exitDy=0;entryX=0.031;entryY=0.369;entryDx=0;entryDy=0;entryPerimeter=0;" parent="1" target="86CSyU7w3ejZ87KWMk9O-1" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="321.9999999999977" y="-1301" as="targetPoint" />
            <Array as="points">
              <mxPoint x="38" y="-856" />
            </Array>
            <mxPoint x="237.99999999999977" y="-271" as="sourcePoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-18" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" edge="1" parent="1" source="86CSyU7w3ejZ87KWMk9O-39" target="86CSyU7w3ejZ87KWMk9O-47">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-39" value="Sonraki Level&#39;e Geç" style="rhombus;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="238" y="-340" width="130" height="130" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-42" style="edgeStyle=none;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;entryX=0;entryY=0.5;entryDx=0;entryDy=0;" parent="1" edge="1">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="237.99999999999977" y="-271" as="sourcePoint" />
            <mxPoint x="237.99999999999977" y="-271" as="targetPoint" />
          </mxGeometry>
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-46" value="Evet" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="118" y="-296" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-47" value="Oyun Bitti" style="ellipse;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="483" y="-300" width="120" height="80" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-51" value="Evet" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="128" y="-681" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-54" value="Hayır" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="388" y="-400" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-60" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" parent="1" source="86CSyU7w3ejZ87KWMk9O-57" target="86CSyU7w3ejZ87KWMk9O-7" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-71" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;exitX=1;exitY=0.5;exitDx=0;exitDy=0;entryX=0;entryY=0.5;entryDx=0;entryDy=0;" parent="1" source="86CSyU7w3ejZ87KWMk9O-57" target="86CSyU7w3ejZ87KWMk9O-66" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-57" value="Şarjör Dolu mu?" style="rhombus;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="320" y="-1026" width="110" height="110" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-61" value="Evet" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="315" y="-916" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-63" value="Hayır" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="428" y="-996" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-19" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;exitX=0.5;exitY=1;exitDx=0;exitDy=0;entryX=0.5;entryY=0;entryDx=0;entryDy=0;" edge="1" parent="1" source="86CSyU7w3ejZ87KWMk9O-66" target="86CSyU7w3ejZ87KWMk9O-47">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-66" value="Cephane Var mı?" style="rhombus;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="488" y="-1023.5" width="110" height="105" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-72" value="Hayır" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="538" y="-906" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-76" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;entryX=1;entryY=0.5;entryDx=0;entryDy=0;" parent="1" source="86CSyU7w3ejZ87KWMk9O-73" target="86CSyU7w3ejZ87KWMk9O-5" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-73" value="Şarjör Doldur&lt;div&gt;(R Tuşu veya Sol Click)&lt;/div&gt;" style="rounded=0;whiteSpace=wrap;html=1;" parent="1" vertex="1">
          <mxGeometry x="578" y="-1116" width="120" height="60" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-74" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;exitX=1;exitY=0.5;exitDx=0;exitDy=0;entryX=0.626;entryY=0.946;entryDx=0;entryDy=0;entryPerimeter=0;" parent="1" source="86CSyU7w3ejZ87KWMk9O-66" target="86CSyU7w3ejZ87KWMk9O-73" edge="1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="86CSyU7w3ejZ87KWMk9O-75" value="Evet" style="text;html=1;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;" parent="1" vertex="1">
          <mxGeometry x="588" y="-996" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-4" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" edge="1" parent="1" source="QPiGmSm-muWGbrL4p8YD-1" target="QPiGmSm-muWGbrL4p8YD-3">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-1" value="Zombi Oyuncuya Saldırır" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
          <mxGeometry x="68" y="-921" width="120" height="60" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-7" value="" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" edge="1" parent="1" source="QPiGmSm-muWGbrL4p8YD-3" target="QPiGmSm-muWGbrL4p8YD-6">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-3" value="Oyuncu Can Azalt" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
          <mxGeometry x="68" y="-1036" width="120" height="60" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-9" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;" edge="1" parent="1" source="QPiGmSm-muWGbrL4p8YD-6" target="86CSyU7w3ejZ87KWMk9O-2">
          <mxGeometry relative="1" as="geometry">
            <Array as="points">
              <mxPoint x="128" y="-1226" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-16" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;exitX=1;exitY=0.5;exitDx=0;exitDy=0;entryX=1;entryY=0.5;entryDx=0;entryDy=0;" edge="1" parent="1" source="QPiGmSm-muWGbrL4p8YD-6" target="86CSyU7w3ejZ87KWMk9O-47">
          <mxGeometry relative="1" as="geometry">
            <mxPoint x="709.9999999999998" y="-255" as="targetPoint" />
            <mxPoint x="290" y="-1156" as="sourcePoint" />
            <Array as="points">
              <mxPoint x="710" y="-1161" />
              <mxPoint x="710" y="-260" />
            </Array>
          </mxGeometry>
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-6" value="Oyuncu Can == 0?" style="rhombus;whiteSpace=wrap;html=1;" vertex="1" parent="1">
          <mxGeometry x="73" y="-1216" width="110" height="110" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-10" value="Hayır" style="text;html=1;whiteSpace=wrap;strokeColor=none;fillColor=none;align=center;verticalAlign=middle;rounded=0;" vertex="1" parent="1">
          <mxGeometry x="80" y="-1241" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-12" value="Evet" style="text;html=1;whiteSpace=wrap;strokeColor=none;fillColor=none;align=center;verticalAlign=middle;rounded=0;" vertex="1" parent="1">
          <mxGeometry x="198" y="-1186" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-13" value="Hayır" style="text;html=1;whiteSpace=wrap;strokeColor=none;fillColor=none;align=center;verticalAlign=middle;rounded=0;" vertex="1" parent="1">
          <mxGeometry x="118" y="-831" width="60" height="30" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-15" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;entryX=0.5;entryY=0;entryDx=0;entryDy=0;" edge="1" parent="1" source="QPiGmSm-muWGbrL4p8YD-14" target="86CSyU7w3ejZ87KWMk9O-1">
          <mxGeometry relative="1" as="geometry" />
        </mxCell>
        <mxCell id="QPiGmSm-muWGbrL4p8YD-14" value="Başla" style="ellipse;whiteSpace=wrap;html=1;" vertex="1" parent="1">
          <mxGeometry x="318.5" y="-1460" width="113" height="80" as="geometry" />
        </mxCell>
      </root>
    </mxGraphModel>
  </diagram>
</mxfile>
<img width="766" height="1251" alt="blokDiyagramı" src="https://github.com/user-attachments/assets/b71fa173-4086-4040-af21-95532f7d6fdb" />

---
## Geliştirenler
* Emre Beraat Samuk- [emresamuk]
* Gülnihal Eruslu- [gulni-hal]
* Metehan Yüksek- [metehan-41]  








