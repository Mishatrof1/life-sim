VAR StoryTittle = ""
VAR StoryQuestion = "What is the largest planet in our galaxy?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18
VAR NPC0OccupationSc = "HigherInPosition"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 64
VAR NPC1RelationshipSc = "Crush"
VAR NPC1GenderSc = "Opposite"

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1SympathyCh = 0

I am taking a test for Science class and am trying to figure out this question.
What is the largest planet in our galaxy?
* [Jupiter]
    -> res1
* [Saturn]
    -> res2
* [Mercury]
    -> res3
* [Pluto]
    -> res4

=== res1 === 
Jupiter is the right answer! And %FullName:NPC:2% mentions that %Pron:2:1% checked my test for the answer and is thankful I got it right.
~TextForLog = "Not only did I pick the right answer of Jupiter but %FullName:NPC:2% mentions that %Pron:2:1% checked what I wrote for my answer and is glad I got it right since I ended up helping %Pron:2:2% out. Didn't even realize I was helping... but happy to help!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
Saturn is the wrong answer.
~TextForLog = "Saturn is the wrong answer. Oh well, I knew it was one of the biggest and has a whole bunch of rings. I figured it was a good guess."
* [Ok]
-> END

=== res3 === 
Mercury is the wrong answer.
~TextForLog = "Mercury is the wrong answer. I also later find out that it is one of the smaller planets... so that wasn't even a good guess. Whoops!"
* [Ok]
-> END

=== res4 === 
Pluto is the wrong answer and is, in fact, wrong for more reasons than one!
~TextForLog = "My teacher %FullName:NPC:1% informs me in front of the whole class that Pluto is very small and also isn't even considered a planet anymore, so this was a really bad choice! I am embarrassed but %FullName:NPC:2% comforts me and makes me feel better about the fact that I only got one stupid question wrong."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
~NPC1SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
