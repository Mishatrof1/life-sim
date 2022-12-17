VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



In our class, we have "A" students who behave themselves, and real naughty guys with poor marks. Who should I join?
* [The naughty guys]
    -> res1
* [The "A" students]
    -> res2
* [I'm on my own and don't need any groups]
    -> res3
* [Try being friends with both groups]
    -> res4

=== res1 === 
Among them, I felt myself the mannest until my parents grounded me for low grades
~TextForLog = "In our class, we have \"A\" students who behave themselves, and real naughty guys with poor marks. I joined the bad guys and felt myself really tough until my parents grounded me for low grades."
* [Ok]
-> END
=== res2 === 
My school results have been pretty good; the bad boys gang have been giving me trouble, though
~TextForLog = "In our class, we have \"A\" students who behave themselves, and real naughty guys with poor marks. I'm with the smart guys now and doing well in my studies, but that other gang have been tough on me."
* [Ok]
-> END
=== res3 === 
It's hard being a lone wolf, there's no one there for you. I've got to try something else
~TextForLog = "In our class, we have \"A\" students who behave themselves, and real naughty guys with poor marks. I decided not to join any group and be on my own."
* [Ok]
-> END
=== res4 === 
I am doing well at school and in good terms with the guys. It's just that nobody takes me seriously
~TextForLog = "In our class, we have \"A\" students who behave themselves, and real naughty guys with poor marks. I chose to be friends with both groups."
* [Ok]
-> END