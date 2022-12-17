VAR StoryTittle = ""
VAR StoryQuestion = "Wait. Where's my invite?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "Kid:PrimarySchool"
VAR Character0MinAgeSc = 4
VAR Character0MaxAgeSc = 5
VAR NPC0RelativesSc = "Parent"
VAR NPC0GenderSc = "Female"
VAR NPC1RelationshipSc = "Friend"
VAR NPC1OccupationSc = "Classmate"
VAR NPC1GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0WisdomCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0

Everyone got invited to %FirstName:NPC:2%'s birthday party! It's going to be great!
Wait. Where's my invite?
* [Ask around to see if anyone else wasn't invited.]
    -> res1
* [Ask %FirstName:NPC:2% direct why %Pron:1:1% didn't invite me!]
    -> res2
* [Ask Mom what I should do about it. ]
    -> res3
* [Forge an invite and attend the party!]
    -> res4

=== res1 === 
I asked a few people in the class and it seems like there were a few of us who didn't get invited. I thought %FirstName:NPC:2% and I were better friends than that. It hurts, but I'm wiser now. 
~TextForLog = "Not getting invited to a party - a rite of passage for everyone, I guess. It hurt, but I'm just that little bit wiser now. "
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res2 === 
%FirstName:NPC:2% was embarrassed. She told me her mom had only allowed her to ask so many people... and I didn't make it to the list. I told her: no hard feelings. 
~TextForLog = "%FirstName:NPC:1% didn't invite me to her party, but at least I had the confidence to ask her outright... and to forgive her. Older and wiser!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:1:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
I asked Mom what I should do about not being invited, and she told me to just ignore it and move on. She was right; it was no big deal and soon I had forgotten all about %FirstName:NPC:1%'s party. 
~TextForLog = "My Mom is such a source of wisdom! She helped me through not being invited to %FirstName:NPC:1%'s precious little birthday party. Thanks, Mom. "
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res4 === 
I managed to photocopy one of %FirstName:NPC:1%'s invites, and turned up to the party. %FirstName:NPC:1% looked a little surprised to see me, but acted like it was fine. We had a great time!
~TextForLog = "If you don't get invited to a party, guess what? Just turn up! It was a brave move, but I got my slice of cake for my troubles. Win/win!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
