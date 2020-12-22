
alter table stadium add column "Capacity" integer;

update stadium set "Capacity"=19000 where "StadiumID"=19;
SELECT * from stadium;

insert into stadium VALUES
(3,'Tottenham Hotspur Stadium','London',62062),
(4,'Etihad Stadium','Manchester',55017),
(5,'London Stadium','London',60000	),
(6,'Anfield','Liverpool',54074),
(7,'St James Park','Newcastle',52338),
(8,'Stamford Bridge','London',40853),
(9,'Goodison Park','Livepool',39571),
(10,'Elland Road','Leeds',37890),
(11,'Bramall Lane','Sheffield',32702),
(12,'St Marys Stadium','Southampton',32384),
(13,'King Power Stadium','Leicester',32273),
(14,'Molineux Stadium','Wolverhampton',32050),
(15,'AMEX Stadium','Brighton',30666),
(16,'The Hawthorns','West Bromwich',26850),
(17,'Selhurst Park','London',26047),
(18,'Turf Moor','Burnley',21994),
(19,'Craven Cottage','London',19.000),
(20,'Old Trafford','Manchester',74879);





