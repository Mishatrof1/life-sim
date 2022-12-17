VAR StoryTittle = ""
VAR StoryQuestion = "%FullName:NPC:2% farts and leaves and %FullName:NPC:1% enters right after. What do I do?"
VAR StoryCategory = "Pink"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 13
VAR NPC0MaxAgeSc = 18
VAR NPC1OccupationSc = "HigherInPosition"
VAR NPC1GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0SympathyCh = 0

I'm at %FullName:NPC:1%'s house, alone with %Pron:1:2% dad, %FullName:NPC:2% talking.
%FullName:NPC:2% farts and leaves and %FullName:NPC:1% enters right after. What do I do?
* [Blame %Pron:1:2% dad]
    -> res1
* [Act like I don't smell anything]
    -> res2
* [Find something to spray to mask the smell]
    -> res3
* [Say that it is my new prescription deodorant]
    -> res4

=== res1 === 
%FullName:NPC:1% yells at %Pron:1:2% dad but now %FullName:NPC:2% is upset with me.
~TextForLog = "Things are ok with me and %FullName:NPC:1% because %Pron:1:1% did believe me even though %FullName:NPC:2% denied it. But now whenever I go over to their place, things are awkward between me and %FullName:NPC:2%."
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% thinks I am the one who farted and like I am just covering it up.
~TextForLog = "%FullName:NPC:1% thinks I farted now, great. I should've just blamed %Pron:1:2% dad. Now, %Pron:1:1% doesn't really want to hang out with me and is avoiding talking to me. Because, as %Pron:1:1% says, I didn't even own up to it. Should I have just said I farted even though I didn't?"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% asks what I am doing and then realizes it's because of the smell.
~TextForLog = "%FullName:NPC:1% immediately kicks me out of the house and then ends up telling a bunch of our friends the next day what I did and everyone is making fun of me now. It smelled awful I was just trying to mask the smell! But that doesn't mean I did it!"
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
%FullName:NPC:1% buys this and just seems to think all is fine.
~TextForLog = "Wow, prescription deodorant. I don't know where  came up with that but I am remembering that one. %FullName:NPC:1% was totally fine with it and the smell eventually went away. %Pron:1:1% did tell me %Pron:1:1% felt badly for my condition. So... now I have a condition, I guess..."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
