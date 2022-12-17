VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "FullTimeJob"
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Female"
VAR NPC1OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0WealthCh = 0

My wife texts me and asks me to print something out for her at my office but I just left work.
What do I do?
* [Turn around and print her stuff out]
    -> res1
* [Just print it out when I go into the office tomorrow]
    -> res2
* [Stop by at an office supply store and print her stuff out there]
    -> res3
* [Ask her to just print it out at the office supply store herself]
    -> res4

=== res1 === 
My wife thanks me but I get stuck in traffic on the way back which is annoying. But I have time to listen to an audiobook of mine.
~TextForLog = "My wife was very happy with me for actually turning back around to print her stuff out but I am annoyed with all the traffic I got stuck in. Took forever to get home, the plus side is that I got to listen to my audiobook finally."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I print the stuff out the next day but my boss sees me and lectures me about using the company printer for personal things.
~TextForLog = "I should’ve just printed her stuff out earlier! My wife is happy that I did this favor for her but things are rocky with my boss now after he caught me using the printer for personal reasons."
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
When I get to the office store someone comes in and robs the place and me! My wife gets mad I didn’t print her stuff out.
~TextForLog = "It’s bad enough I got robbed at the office supply store but then my wife actually is angry with me for not printing her stuff out! I was trying to, it’s not my fault I didn’t get to... unbelievable!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-300%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
My wife is annoyed that I make her do it and doesn’t talk to me when I get home. But then I get a chance to listen to my audiobook.
~TextForLog = "My wife gets annoyed that I make her print her own stuff out but I didn’t feel like turning around. It was quiet at home so I got to listen to my audiobook... but I hope it doesn’t stay this quiet in the house for too long..."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
