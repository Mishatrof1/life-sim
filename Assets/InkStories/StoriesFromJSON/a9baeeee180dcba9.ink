VAR StoryTittle = ""
VAR StoryQuestion = "She wants us to do something this weekend and wants me to pick something. What should I pick?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 65
VAR Character0GenderSc = "Male"
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Female"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 65

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0IntelligenceCh = 0

%FullName:NPC:1% says that we haven't spent much time together lately.
She wants us to do something this weekend and wants me to pick something. What should I pick?
* [Tell her I'll take her to her favorite restaurant]
    -> res1
* [Tell her I'll take her to a museum]
    -> res2
* [Surprise %FullName:NPC:1% with tickets to a play.]
    -> res3

=== res1 === 
Not until after the dinner does %FullName:NPC:1% express that she's upset with this choice.
~TextForLog = "Instead of telling me before, %FullName:NPC:1% waits until I spend a bunch of money on a big, expensive meal and then tells me that she's upset. Apparently, we go here too often and this is what I always decide that we should do when she wants to spend time. And she wants me to try harder and be more creative. Jeez, she couldn't have said that before?!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-120%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
We have a great time at this museum that we both have never been to.
~TextForLog = "%FullName:NPC:1% really enjoys the museum, as do I. She is also really happy that I chose something different from the usual of restaurants and movies and what not. And I am glad I chose the museum too, I hadn't been to one in a while and had forgotten how much I love attending museums and learning from them."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-40%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% loves the idea of going to this play and loves that I surprised her!
~TextForLog = "Surprising %FullName:NPC:1% was probably my best option. I think doing something like that, surprising her, really lit a little spark in our relationship. I wanted to let her know we can still have surprises... and she loved the idea of the play! So, I really did a good job with this one."
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-70%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END
