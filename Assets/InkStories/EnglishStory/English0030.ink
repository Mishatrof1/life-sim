VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Male"
VAR GroupTitle = "School"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0



My classmates make fun of me cuz I'm the last virgin in the whole class. How can I regain my reputation?
* [Virginity speaks for spiritual purity. I don't care about them]
    -> res1
* [Get a hooker and make a video of us having sex]
    -> res2
* [Ask the guys to take me to a sex party]
    -> res3
* [The truth is I don't like women. But I'll just tell them I'm in love with a teacher]
    -> res4

=== res1 === 
I lost my face in their eyes but I have my dignity
~TextForLog = "My classmates make fun of me cuz I'm the last virgin in the whole class. I don't care! Virginity is a symbol of spiritual purity."
* [Ok]
-> END
=== res2 === 
I enjoyed it, but I should have used protection. The treatment was costy, and it was quite a shame, but I'm a real macho in our class now
~TextForLog = "My classmates make fun of me cuz I'm the last virgin in the whole class. I got a hooker, and it was nice, but I should have used protection. The treatment was costy, and it was quite a shame, but I'm a real macho in our class now."
* [Ok]
-> END
=== res3 === 
I hooked up with a girl there. We were having sex, but I was super fast. Of course, she told everyone about it. It's even worse than being a virgin!
~TextForLog = "My classmates make fun of me cuz I'm the last virgin in the whole class. I went to a sex party and hooked up with a girl there. We were having sex, but I was super fast. Of course, she told everyone about it. It's even worse than being a virgin!"
* [Ok]
-> END
=== res4 === 
The guys bought it... as well as the teacher. After school, she literally jumped on me! This is crazy, she won't leave me alone...
~TextForLog = "My classmates make fun of me cuz I'm the last virgin in the whole class. The truth is I don't like women. But I just told them I was in love with a teacher. They bought it... as well as the teacher. After school, she literally jumped on me! This is crazy, she won't leave me alone..."
* [Ok]
-> END