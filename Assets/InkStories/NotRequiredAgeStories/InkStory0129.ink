VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Наш самолет захватили террористы. Их двое. Из оружия у них только специальные пластиковые ножи. Что делать?
* [Выполнять все требования захватчиков]
    -> res1
* [Сговориться с другими пассажирами и скрутить террористов]
    -> res2
* [Найти способ сообщить властям о захвате]
    -> res3
* [В одиночку вступить в противоборство с террористами]
    -> res4

=== res1 === 
Я и другие пассажиры выполняли требования террористов, а в результате оказалось, что это экстремальные учения службы безопасности иностранной авиакомпании. Придурки!
~TextForLog = "Наш самолет захватили террористы. Их было двое, вооруженных специальными пластиковыми ножами. Я выполнил все требования террористов. К счастью, это оказались не настоящие террористы, а участники учений по безопасности."
* [Ok]
-> END
=== res2 === 
Я сговорился с крепким парнем из Техаса и мы, уничтожили обоих террористов. Но оказалось, что это не террористы, а сотрудники иностранной авиакомпании, участвующие в экстремальных учениях по безопасности
~TextForLog = "Наш самолет захватили террористы. Их было двое, вооруженных специальными пластиковыми ножами. Я сговорился с одним крепким парнем, и мы уничтожили обоих террористов. Увы, это оказались не настоящие террористы, а участники учений по безопасности."
* [Ok]
-> END
=== res3 === 
Я сумел спрятать свой смартфон и позвонить в полицию. Начался хаос, но в конце выяснилось, что это учения, которые устроила служба безопасности иностранной авиакомпании
~TextForLog = "Наш самолет захватили террористы. Их было двое, вооруженных специальными пластиковыми ножами. Я сумел сообщить в полицию о случившемся. Но оказалось, что это не террористы, а сотрудники иностранной авиакомпании, участвующие в экстремальных учениях по безопасности."
* [Ok]
-> END
=== res4 === 
Я обезвредил их обоих. Считал себя героем, а оказалось, что это не террористы, а участники экстремальных учений службы безопасности иностранной компании
~TextForLog = "Наш самолет захватили террористы. Их было двое, вооруженных специальными пластиковыми ножами. Я обезвреди обоих. Но оказалось, что это не террористы, а сотрудники иностранной авиакомпании, участвующие в экстремальных учениях по безопасности."
* [Ok]
-> END