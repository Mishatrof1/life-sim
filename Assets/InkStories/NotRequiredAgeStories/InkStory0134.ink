VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Семья"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Моя жена разжирела и не следит за собой. Я перестал испытывать к ней сексуальное влечение. Что делать?
* [Обратиться к сексопатологу]
    -> res1
* [Обратиться к жрецу Вуду]
    -> res2
* [Найти себе любовницу]
    -> res3
* [Откровенно поговорить с женой на эту тему]
    -> res4

=== res1 === 
Сексопатолог - классная, мне нравится ходить к ней на сеансы, может попробовать индивидуальную терапию?
~TextForLog = "Моя жена разжирела и перестала следить за собой. Я перестал испытывать к ней сексуальное влечение. Мы обратились к сексопатологу."
* [Ok]
-> END
=== res2 === 
Ну, в целом, это выход. Но только временный
~TextForLog = "Моя жена разжирела и перестала следить за собой. Я перестал испытывать к ней сексуальное влечение. Мы обратились к жрецу Вуду. Он помог."
* [Ok]
-> END
=== res3 === 
Ну, в целом, это выход. Но только временный
~TextForLog = "Моя жена разжирела и перестала следить за собой. Я перестал испытывать к ней сексуальное влечение. Я завел себе любовницу."
* [Ok]
-> END
=== res4 === 
Жена устроила мне скандал. Это она может, а вот с собой сделать что-нибудь не может
~TextForLog = "Моя жена разжирела и перестала следить за собой. Я перестал испытывать к ней сексуальное влечение. Я поговорил с ней об этой проблеме. Дело кончилось скандалом."
* [Ok]
-> END