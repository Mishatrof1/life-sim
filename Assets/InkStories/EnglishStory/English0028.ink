VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "Family"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



I caught my father was a lover. What should I do?
* [Charge him 200 bucks to keep quiet]
    -> res1
* [Tell Mom everything]
    -> res2
* [Demand Dad to end it with this slut]
    -> res3
* [Not interfere, this is his life]
    -> res4

=== res1 === 
I let my father and that woman enjoy each other and used the money to have fun at a nightclub
~TextForLog = "I caught my father was a lover. For 200 bucks, I let my father and that woman enjoy each other and had fun at a nightclub."
* [Ok]
-> END
=== res2 === 
Mom kicked Dad out, and he stayed at that woman's for a month. He's back now, but our family will never be the same
~TextForLog = "I caught my father was a lover and told Mom about it. Mom kicked Dad out, and he stayed at that woman's for a month. He's back now, but our family will never be the same."
* [Ok]
-> END
=== res3 === 
Me and Dad nearly had a fight, but finally he left her. Later, Dad thanked me for my reaction
~TextForLog = "I caught my father was a lover and demamnded him to end it with that slut. Me and Dad nearly had a fight, but finally he left her. Later, Dad thanked me for my reaction."
* [Ok]
-> END
=== res4 === 
We have a strong family, but only on the surface. I know the truth and feel sorry for Mom, but I'll keep silent
~TextForLog = "I caught my father was a lover but decided not to interfere. We have a strong family, but only on the surface. I know the truth and feel sorry for Mom, but I'll keep silent."
* [Ok]
-> END