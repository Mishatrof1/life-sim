VAR AgeMinCondition = 5
VAR AgeMaxCondition = 7
VAR SexCondition = "Female"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



A girl at school keeps bullying me. How should I act?
* [Offer her to be friends]
    -> res1
* [Punch her]
    -> res2
* [Tell the teacher on her]
    -> res3
* [Ignore her]
    -> res4

=== res1 === 
She said she would never be friends with such a piss-ant. I feel hurt
~TextForLog = "A girl at school kept bullying me. I offered her to be friends, but she rejected me. I feel hurt."
* [Ok]
-> END
=== res2 === 
She punched me back, and we fought. Now, we are both going to be given detention, and maybe even expelled
~TextForLog = "A girl at school kept bullying me. I got mad and had a fight with her. We were both given detention."
* [Ok]
-> END
=== res3 === 
That girl got detention, and I'm not so popular with my classmates now
~TextForLog = "A girl at school kept bullying me. I told the teacher on her, and she was punished. However, it was a bad PR for me at school."
* [Ok]
-> END
=== res4 === 
That girl kept bullying me for a while, but finally left me alone
~TextForLog = "A girl at school kept bullying me. I ignored her, and she finally left me alone."
* [Ok]
-> END