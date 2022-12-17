VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "Family"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I saw Mom trying to crack the password to Dad's phone. My actions?
* [Help her. I want to get acces to his bank account]
    -> res1
* [Tell her she's doing the wrong thing]
    -> res2
* [It's none of my business; let my parents sort it out themselves]
    -> res3
* [Tell Dad about it]
    -> res4

=== res1 === 
Dad turned out to be bankrupt cuz she spent all the money on a lover. Our life has been a nightmare!
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
Mom said it was just a moment of weakness and asked me not to tell Dad. All right, I won't
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
Dad turned out to be bankrupt cuz she spent all the money on a lover. Our life has been a nightmare!
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
I helped Dad to protect his secret life better. We all have our little secrets, after all
~TextForLog = ""
* [Ok]
-> END