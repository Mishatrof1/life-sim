VAR StoryTittle = ""
VAR StoryQuestion = "What do I get for him?"
VAR StoryCategory = "Beige"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool:College"
VAR NPC0RelativesSc = "Parent:StepParent"
VAR NPC0GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0IntelligenceCh = 0

My father texts me and tells me to bring home pasta sauce for him to make dinner.
What do I get for him?
* [The store brand sauce that is cheap]
    -> res1
* [The expensive sauce with the gold label]
    -> res2
* [The medium-priced sauce with the red label]
    -> res3
* [Get him both the expensive sauce and the cheap, store brand sauce]
    -> res4

=== res1 === 
My father gets mad at me for bringing him the cheap stuff but everyone ends up loving the pasta and I’m quite pleased, plus I saved some money.
~TextForLog = "My father was annoyed that I bought the cheap stuff but I didn’t know which one he wanted and didn’t want to waste so much money. Joke’s on him, it turned out to taste really good!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%5%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
My father is glad I got the right pasta sauce and we bond as he makes his pasta.
~TextForLog = "Sure, I may have been out a few extra bucks but I was glad I picked the right sauce and had a good time cooking with my dad."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-3%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
My father is interested in this one because we’ve never tried it. We have a good time making the pasta but the food ends up tasting awful!
~TextForLog = "My father and I had a great time cooking and we were both intrigued to try out the new sauce but wow... it was just terrible. Now, we know, red label is out!"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
My father laughs but appreciates my initiative. He teaches me the difference between the two sauces and teaches me some cooking tips.
~TextForLog = "I’m glad I gave my father options because I didn’t want to bring the wrong sauce to him. I may have wasted some money but I ended up learning a lot about cooking and had a great time!"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-8%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
