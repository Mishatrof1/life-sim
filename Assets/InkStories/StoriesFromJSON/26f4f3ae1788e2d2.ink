VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "HigherInPosition"
VAR NPC0MinAgeSc = 30
VAR NPC0MaxAgeSc = 60

VAR Character0HealthCh = 0
VAR Character0StrengthCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0

My boss %FullName:NPC:1% asks me if I want to do some training through work tomorrow.
What should I do?
* [Say no, I'll just do my normal work.]
    -> res1
* [I'll do the training to learn how to train others.]
    -> res2
* [Take the training on management]
    -> res3

=== res1 === 
A lot of other people do the training so I have a lot of work to do, a lot of moving boxes around.
~TextForLog = "It's a long day, especially since so many other people did training. I ended up having so much extra work to do. So many boxes had to be moved around and organized and I got to do all of it! Lucky me, right? I am just glad for this long day to be done with."
~Character0HealthCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
The training goes over how to train other employees and I learn a lot.
~TextForLog = "%FullName:NPC:1% is glad I took some training and now I am a certified trainer and can train new employees. The training course was really insightful and I learned a lot. I am ready to teach!"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
The training on management is really interesting and after I finish my boss %FullName:NPC:1% gives me a raise and a promotion.
~TextForLog = "My raise kicked in immediately and I earned $30 for doing the training. And my boss %FullName:NPC:1% is proud of me for taking this step. Wow, I am so glad I took this class. Also, it's going to be great to take steps towards management and be able to put that on my resume."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%30%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
