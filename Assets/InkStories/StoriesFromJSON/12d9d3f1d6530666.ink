VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0MinAgeSc = 6
VAR Character0MaxAgeSc = 15
VAR NPC0RelativesSc = "Kid:AdoptedKid"
VAR NPC0MinAgeSc = 6
VAR NPC0MaxAgeSc = 15

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0

My kid needs help with a science project and %Pron:1:3% math homework.
What do I do?
* [Tell %Pron:1:2% I’ll help with math homework and %Pron:1:3% mother will help with %Pron:1:3% project]
    -> res1
* [Tell %Pron:1:2% I’ll help with science project and  mother will help with %Pron:1:3% homework]
    -> res2
* [Tell %Pron:1:2% I’ll help with both]
    -> res3
* [Tell %Pron:1:2% to ask %Pron:1:3% mother for help with both.]
    -> res4

=== res1 === 
I remember that math was actually a strong subject of mine and I help %Pron:1:2% ace the homework, plus my wife does a great job with %Pron:1:3% project.
~TextForLog = "My kid and I bond while working on %Pron:1:3% math homework and we have a great time. And the math is all rushing back to me!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
Science was never a good subject of mine and my kid gets upset with me because %Pron:1:1% gets a bad grade.
~TextForLog = "Things don’t go well working on my kid’s science project and %Pron:1:1% gets a bad grade and is pretty upset with me. Why didn’t I remember I was so bad at science?!"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
We work so long on the math homework that we get tired working on %Pron:1:3% project and I accidentally light my hair on fire.
~TextForLog = "Well, we worked so hard on %Pron:1:3% math homework I was basically falling asleep and then literally set my hair on fire! We put it out quickly but it didn’t stop me from getting burnt. But my kid and I had a good laugh over it."
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
My kid is upset I don’t help %Pron:1:2% with anything but I have a lot to do. I also have time to finish a book I’ve been meaning to get to.
~TextForLog = "I got a lot of stuff done and finally got around to reading a book I wanted to read. It was nice to have time to myself but I do feel badly since my kid seems upset that I didn’t help %Pron:1:2%."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
