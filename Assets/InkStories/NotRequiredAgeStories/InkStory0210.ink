VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Муж заявил, что я слишком времени провожу с моими подругами и мало внимания уделяю семье. Как реагировать?
* [Пойти на конфронтацию. Это мое дело и мое время]
    -> res1
* [Я должна считаться с мнение мужа, поэтому изменю свое поведение]
    -> res2
* [У меня есть тоже парочка претензий, и если я пойду навстречу мужу, то и муж должен поступить так же]
    -> res3
* [Я не готова обсуждать это. Лучше в другой раз]
    -> res4

=== res1 === 
Мы поругались, никто не уступил, и каждый остался при своем интересе
~TextForLog = "Муж заявил, что я слишком времени провожу с моими подругами и мало внимания уделяю семье. Я пошла на конфронтацию и мы с мужем поругались."
* [Ok]
-> END
=== res2 === 
Муж был очень доволен. Люблю его и мне всегда радостно, когда он доволен
~TextForLog = "Муж заявил, что я слишком времени провожу с моими подругами и мало внимания уделяю семье. Я согласилась с его мнением и муж был мне очень благдарен за это."
* [Ok]
-> END
=== res3 === 
Мы обменялись притензиями и начали работу по их устранению
~TextForLog = "Муж заявил, что я слишком времени провожу с моими подругами и мало внимания уделяю семье. Я тоже заявила ему свои претензии и мы решили пойти навстречу друг другу."
* [Ok]
-> END
=== res4 === 
Это так утомительно, семейные споры. Лучше я поообщаюсь с подругами
~TextForLog = "Муж заявил, что я слишком времени провожу с моими подругами и мало внимания уделяю семье. Я не пожелала обсуждать это, потому что не люблю подобные разговоры."
* [Ok]
-> END