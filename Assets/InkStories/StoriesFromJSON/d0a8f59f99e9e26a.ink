VAR StoryTittle = ""
VAR StoryQuestion = "I hate broccoli! What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 3
VAR Character0MaxAgeSc = 5
VAR NPC0RelativesSc = "Parent"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0WisdomCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

Dad cooked lasagne, my favourite! But what's this on the side... broccoli?
I hate broccoli! What should I do?
* [Thank Dad for cooking, and eat all the broccoli. ]
    -> res1
* [Tell Dad that he should know that I hate broccoli! ]
    -> res2
* [Hide some of the broccoli under my knife and fork. ]
    -> res3

=== res1 === 
Dad doesn't cook that often, so I put on a brave face and tried to eat all the broccoli, every last scrap. I ended up puking a bit... and dad was a little upset, though proud I'd tried. 
~TextForLog = "Dad cooked my favourite meal and, although I tried to eat all my broccoli to stop myself seeming ungrateful, it backfired and I was ill. Dad was a little sad, but impressed too."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
When I told Dad that I hated broccoli, he looked surprised and a little hurt. He then gave me a long talk about healthy eating. By the time I got to each the lasagne, it was cold! Yuk!
~TextForLog = "I shouldn't have been so mean to my dad about the broccoli today. He was sad, and I had to each some of the broccoli anyway. Yuk!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
I gobbled up the lasagne that Dad cooked and it was delicious. I managed to hide half the broccoli and, because he didn't do the washing up, Dad never found out. Win all around!
~TextForLog = "The oldest tricks are the best. It's amazing how much of your most-hated vegetable you can hide under a simple knife and fork! And I got away with it, too!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
