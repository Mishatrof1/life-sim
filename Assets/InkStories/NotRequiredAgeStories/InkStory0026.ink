VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "Школа"
VAR TextForLog = ""

VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Одноклассник позаимствовал у своего отца авто и зовет кататься. Что делать?
* [Поехать с ним в качестве пассажира]
    -> res1
* [Отказаться, так как это опасно и незаконно]
    -> res2
* [Согласиться и самому сесть за руль]
    -> res3
* [Отговорить, пригрозив сообщить обо всем его отцу]
    -> res4

=== res1 === 
Мы доехали до первого встречного полицейского и остаток дня провели в участке. Хорошо, что не я был за рулем
~TextForLog = "Одноклассник позаимствовал у своего отца авто и позвал меня кататься. Мы доехали до первого встречного полицейского и остаток дня провели в участке. Хорошо, что не я был за рулем."
* [Ok]
-> END
=== res2 === 
Он назвал меня трусом, уехал и разбил отцовскую машину. И откуда берутся такие идиоты?
~TextForLog = "Одноклассник позаимствовал у своего отца авто и позвал меня кататься. Я отказался и он назвал меня трусом, уехал и разбил отцовскую машину. И откуда берутся такие идиоты?"
* [Ok]
-> END
=== res3 === 
О, что это была за поездка... Одноклассник чуть не обмочился от страха, но все закончилось ОК
~TextForLog = "Одноклассник позаимствовал у своего отца авто и позвал меня кататься. Я согласился, сел за руль и классно погонял по городу."
* [Ok]
-> END
=== res4 === 
Он вернул машину в гараж. Опасным приключениям место в кино, а не в жизни.
~TextForLog = "Одноклассник позаимствовал у своего отца авто и позвал меня кататься. Я пригрозил пожаловаться его отцу и поездка не состоялась. Опасным приключениям место в кино, а не в жизни."
* [Ok]
-> END