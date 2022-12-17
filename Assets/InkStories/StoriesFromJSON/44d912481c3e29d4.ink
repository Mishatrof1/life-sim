VAR StoryTittle = ""
VAR StoryQuestion = "%FullName:NPC:1% will be waiting on me as we have plans though. What should I do?"
VAR StoryCategory = "Love:Employer"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 22
VAR Character0MaxAgeSc = 35
VAR NPC0RelationshipSc = "SignificantOther"
VAR NPC0MinAgeSc = 22
VAR NPC0MaxAgeSc = 35
VAR NPC1OccupationSc = "HigherInPosition"
VAR NPC1GenderSc = "Opposite"

VAR NPC0HappinessCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0PopularityCh = 0
VAR NPC0RelationshipCh = 0

My boss %FullName:NPC:2% asked if I can stay after work to give my opinion on some outfits %Pron:2:1% bought.
%FullName:NPC:1% will be waiting on me as we have plans though. What should I do?
* [Say no, I don't think I would give good insight.]
    -> res1
* [Say that I would but I have plans after work.]
    -> res2
* [Say sure and give honest opinion on clothes.]
    -> res3
* [Say sure and just say everything looks great]
    -> res4

=== res1 === 
%FullName:NPC:2% gets upset with me. But I leave on time and get home on time.
~TextForLog = "I don't know if I was being too blunt or what, but %FullName:NPC:2% actually got upset with me. I mean, it was a kind of weird question. %Pron:2:1% is my boss and it isn't work related and I'm not single and I couldn't tell if %Pron:2:1% was hitting on me. Anyway, %FullName:NPC:1% was at least happy I got home on time."
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:2% is alright with this and tells me to have a good time.
~TextForLog = "I think being honest and using a bit of diplomacy got me out of an awkward situation. It felt like %FullName:NPC:2% was kind of hitting on me and I know %FullName:NPC:1% would be waiting on me. This way, no one got mad at me. Everyone was happy with me. So... win-win, right?"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:2% shows me the clothes and I am honest in which ones I like and don't like and %FullName:NPC:2% appreciates the honesty.
~TextForLog = "Well, %FullName:NPC:2% appreciated my honesty, even though I thought some outfits weren't great. But %FullName:NPC:1% was mad that I got home late and that %Pron:1:1% had to wait on me. I didn't tell %Pron:1:2% what I was doing because %FullName:NPC:2% also showed me some outfits that, let's say, you would not wear to work. Definitely think %Pron:2:1% was flirting with me."
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
Well, telling %FullName:NPC:2% everything looked great prompted %Pron:2:2% to send me pictures of %Pron:2:2% wearing the outfits and %FullName:NPC:1% sees.
~TextForLog = "Not only was %FullName:NPC:1% mad that I got home late, but then %FullName:NPC:2% is sending me pictures of %Pron:2:2% wearing some outfits... and not work outfits at all... and %FullName:NPC:1% sees and is livid! Meanwhile, %FullName:NPC:2% loved that I told %Pron:2:2% everything looked great and is really coming on strong to me now. Awkward! Everyone at work thinks it's awesome."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:1:+%"
~NPC1RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END
