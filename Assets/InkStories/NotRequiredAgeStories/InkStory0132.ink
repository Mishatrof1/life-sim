VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Семья"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

У сына моей подруги с детства энурез. А недавно я узнала, что он мучает животных и любит все поджигать. Похоже на триаду Макдональда. Что делать?
* [Убедить родителей мальчика обратиться к психиатру]
    -> res1
* [Не вмешиваться. Это не мое дело..]
    -> res2
* [Убедить его родителей обратиться к жрецу Вуду, чтобы вылечил мальчика]
    -> res3
* [Напугать мальчика страшными последствиями его действий]
    -> res4

=== res1 === 
Парня взяли на учет. Надеюсь, из него не вырастит серийный убийца
~TextForLog = "У сына моей подруги была триада Макдональда. Я убедила родителей мальчика обратиться к психиатру."
* [Ok]
-> END
=== res2 === 
Он становится только хуже. Иногда мне страшно, но я не знаю, что предпринять
~TextForLog = "У сына моей подруги была триада Макдональда. Я решила не вмешиваться."
* [Ok]
-> END
=== res3 === 
Мне удалось убедить родителей мальчика. Жрец провел обряд, и теперь этот маленький монстр ведет себя, как зомби. Чую, однажды он начнет жрать мозги
~TextForLog = "У сына моей подруги была триада Макдональда. Мне удалось убедить родителей мальчика обратиться к жрецу Вуду и этот маленький монстр стал вести себя, как зомби."
* [Ok]
-> END
=== res4 === 
Он заплакал и обоссался, а его мама накричала на меня. Как бы он не затаил злобу и не выбрал меня своей первой жертвой
~TextForLog = "У сына моей подруги была триада Макдональда. Я напуга мальчика страшными последствиями его действий, он испугался, но затаил на меня злобу."
* [Ok]
-> END