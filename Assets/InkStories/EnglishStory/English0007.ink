VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Female"
VAR GroupTitle = "Outside world"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I was sitting on concrete stairs when that old lady told me to get up, or I would never ever have children. My actions?
* [Get up immediately and thank her for caring]
    -> res1
* [Troll the old lady and stay where I was]
    -> res2
* [Get up and leave, she might be a witch!]
    -> res3
* [Get up, but look up for more information on the Internet]
    -> res4

=== res1 === 
The old lady nodded at me and left. Nothing interesting
~TextForLog = "I was sitting on concrete stairs. An old lady told me to get up, or I would never ever have children. So, I did and thanked her for caring."
* [Ok]
-> END
=== res2 === 
I got sick and had to go to the hospital. I should have listened to the old lady!
~TextForLog = "I was sitting on concrete stairs. An old lady told me to get up, or I would never ever have children. I didn't listen to her and got sick."
* [Ok]
-> END
=== res3 === 
It creeps me out to think that the old lady cursed me!
~TextForLog = "I was sitting on concrete stairs. An old lady told me to get up, or I would never ever have children. I got up and left, as I was scared that the old lady could curse me."
* [Ok]
-> END
=== res4 === 
It turned out not that bad a problem, but there was still a chance to get sick
~TextForLog = "I was sitting on concrete stairs. An old lady told me to get up, or I would never ever have children. I got up and later searched for information on the Internet. It turned out she was partly right."
* [Ok]
-> END