VAR StoryTittle = ""
VAR StoryQuestion = "It turns out this is %FullName:NPC:1%'s sibling so, what should I say now?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18
VAR NPC0OccupationSc = "Classmate"
VAR NPC0MinAgeSc = 8
VAR NPC0MaxAgeSc = 18

VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0

I am hanging out with some classmates before class when I see this annoying person walk by and I comment on how this person is annoying.
It turns out this is %FullName:NPC:1%'s sibling so, what should I say now?
* ["I'm just messing with you!"]
    -> res1
* ["So, you know what I mean, huh?"]
    -> res2
* ["Don't worry, everyone's sibling is annoying."]
    -> res3

=== res1 === 
Nobody buys this, especially %FullName:NPC:1%, and now they all think I'm a jerk.
~TextForLog = "I suppose I shouldn't have commented on random people when talking to classmates I don't know so well. You never know who is related to who. Now, %FullName:NPC:1% thinks I'm a jerk, as do many of my other classmates."
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
When I say this jokingly, %FullName:NPC:1% laughs about it and agrees with me.
~TextForLog = "Whoa, saved myself there! Not wavering and just being lighthearted and funny about it, %FullName:NPC:1% and everyone else got a good laugh about it and didn't think I genuinely despised this person... even though I kind of do. That's a smart way to get myself out of a jam!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
Everyone except %FullName:NPC:1% laughs about this.
~TextForLog = "Every one of my classmates was laughing about this and telling me I'm so funny, except for %FullName:NPC:1% who is staring daggers at me the rest of the day. Oops! At least everyone else is on my side."
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
