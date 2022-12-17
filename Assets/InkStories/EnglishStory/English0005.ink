VAR AgeMinCondition = 5
VAR AgeMaxCondition = 7
VAR SexCondition = "Male"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



A classmate asked me to let him copy my homework. What should I do? 
* [Let him do it]
    -> res1
* [Not to let him do it, he has to do his homework himself!]
    -> res2
* [Charge him twenty bucks for it]
    -> res3
* [Report him to the teacher]
    -> res4

=== res1 === 
The teacher figured it all out and gave us both detention
~TextForLog = "A classmate asked me to let him copy my homework, and I did. But the teacher figured it out and gave us both detention."
* [Ok]
-> END
=== res2 === 
He copied someone else's homework, and I'm not so popular with my classmates now
~TextForLog = "A classmate asked me to let him copy my homework, but I refused and it was bad PR for me at school."
* [Ok]
-> END
=== res3 === 
He didn't have any money, so he copied someone else's homework. I think I'll stick to this solution from now on
~TextForLog = "A classmate asked me to let him copy my homework. I offered to charge him twenty bucks for it, but he didn't have any money and left me alone. I think I'll stick to this solution  in the future."
* [Ok]
-> END
=== res4 === 
He got detention and later attacked me in the toilet. He pushed me, and I got right into the doodies. Yuck!
~TextForLog = "A classmate asked me to let him copy my homework. I reported him to the teacher, and he later took revenge on me by pushing me onto the poop in the toilet."
* [Ok]
-> END