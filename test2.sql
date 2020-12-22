SELECT * FROM "team" join stadium using("StadiumID");
insert into team values
(3,'Tottenham Hotspur',3,'Club/Tottemham.png'),
(4,'Manchester City',4,'Club/Manchestercity.png'),
(5,'West Ham United',5,'Club/Westham.png'),
(6,'Livepool',6,'Club/Livepool.png'),
(7,'Newcastle',7,'Club/Newcastle.png'),
(8,'Chelsea',8,'Club/Chelsea.png'),
(9,'Everton',9,'Club/Everton.png'),
(10,'Leeds United',10,'Club/Leeds.png'),
(11,'Sheffield United',11,'Club/Sheffield.png'),
(12,'Southampton',12,'Club/Southampton.png'),
(13,'Leicester City',13,'Club/Leicester.png'),
(14,'Wolverhampton Wanderers',14,'Club/Wolverhampton.png'),
(15,'Brighton & Hove Albion',15,'Club/Brighton.png'),
(16,'West Bromwich Albion',16,'Club/Westbrom.png'),
(17,'Crystal Palace',17,'Club/Crystalpalace.png'),
(18,'Burnley FC',18,'Club/Burnley.png'),
(19,'Fulham FC',19,'Club/Fulham.png'),
(20,'Manchester United',20,'Club/Manchesterunited.png');

update team set "TeamImage"='Club/Liverpool.png' where "TeamID"=6;

