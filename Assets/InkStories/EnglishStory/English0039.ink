VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I was swimming in the lake when my leg cramped up. I panicked and started to drown. What should I do?
* [Cry for help, actively splashing my hands on the water]
    -> res1
* [Try to calm down and swim to the shore through the pain]
    -> res2
* [Try to stay afloat and rub my leg to ease the cramp]
    -> res3
* [Stop struggling and accept my destiny]
    -> res4

=== res1 === 
I nearly drowned, but they rescued me and brought me back
~TextForLog = ""
* [Ok]
-> END
=== res2 === 
I swam for as long as I could; then, they noticed me from the shore and came to the rescue
~TextForLog = ""
* [Ok]
-> END
=== res3 === 
The pain ceased, I could move my leg again and reached the shore
~TextForLog = ""
* [Ok]
-> END
=== res4 === 
I woke up in a hospital after two months of coma. Really, I survived by a miracle
~TextForLog = ""
* [Ok]
-> END