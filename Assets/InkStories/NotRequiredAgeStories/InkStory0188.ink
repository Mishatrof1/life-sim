﻿VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я  поймал себя на том, что заглядываюсь на совсем юных девушек, втрое младше меня. А ровесницы меня уже не интересуют. Что делать?
* [Подавлять подобные устремления]
    -> res1
* [Воспользоваться услугами молодых совершеннолетних проституток]
    -> res2
* [Отправиться в экзотическую страну, где секс-туризм разрешен законом]
    -> res3
* [Обходиться мастурбацией]
    -> res4

=== res1 === 
Педофилу место в тюрьме, а я не педофил, поэтому полный запрет на подобные мысли
~TextForLog = "Я стал заглядываться на совсем юных девушек, втрое младше меня.  Я решительно подавил подобные устремления. Педофилу место в тюрьме!"
* [Ok]
-> END
=== res2 === 
Дороговато и не совсем то, чего мне хотелось
~TextForLog = "Я стал заглядываться на совсем юных девушек, втрое младше меня. Я воспользоваться услугами молодых совершеннолетних проституток."
* [Ok]
-> END
=== res3 === 
Вместо нежных рук юных красавиц, я побывал в волосатых лапах местных грабителей. Ноги унес, но не свои деньги
~TextForLog = "Я стал заглядываться на совсем юных девушек, втрое младше меня. Я отправился в экзотическую страну, где секс-туризм разрешен законом. Но вместо секса меня там избили и ограбили."
* [Ok]
-> END
=== res4 === 
Полный сервис бесплатно и в любое время. Интересно, много ли на свете столь мудрых решений сложных проблем?
~TextForLog = "Я стал заглядываться на совсем юных девушек, втрое младше меня. Это не проблема, я обошелся мастурбацией."
* [Ok]
-> END