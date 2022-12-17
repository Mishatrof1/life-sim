VAR StoryTittle = ""
VAR StoryQuestion = "What should we do?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 17
VAR Character0MaxAgeSc = 23
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0EnduranceCh = 0
VAR Character0WisdomCh = 0

Me and %FullName:NPC:1% get lost in the woods for a long time and are trying to find something to eat and come across many different mushrooms.
What should we do?
* [Eat the mushroom that looks like a lion's mane.]
    -> res1
* [Eat the mushroom with lots of long, stringy bits.]
    -> res2
* [Eat the red and white mushroom.]
    -> res3

=== res1 === 
This mushroom has a decent taste but it is pretty filling and restores some energy. Also, we start to be able to focus better and find our way out of the woods.
~TextForLog = "We're so happy we chose that mushroom. We realized later it actually is a mushroom touted for helping you to focus and concentrate. After we ate it we sat down and devised a plan on how to get out of the woods and it worked! I might go back for some more of those mushrooms!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
This mushroom instantly gives us a ton of energy, which is great. We are rejuvenated and able to keep going through the woods and eventually find our way out, even though it takes a while.
~TextForLog = "This mushroom gave us so much energy, we even decided to pick up our walk to a brisk jog ad we searched for a way out of the woods. It took a while to get out but we eventually made it out and still felt full of energy."
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
Uh oh, this is one of THOSE mushrooms. We start to see things and don't know what's going on and just sit down and spend the night in the woods.
~TextForLog = "Well, the mushroom eventually made me throw up... several times. I am really hurting the next day. But %FullName:NPC:1% didn't throw up. But we both were having quite the experience, we just camped out in the woods all night and woke up the next morning feeling like we got in touch with the Earth and really learned a lot about ourselves. We were able to survive overnight in the woods!"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%%"
* [Ok]
-> END
