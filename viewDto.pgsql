create or replace view match_info_dto4 AS
select *,
(select t."TeamName" as HomeName from team t,match m where t."TeamID"=m."HomeResTeamID" and m."MatchID"=m1."MatchID"),
(select t."TeamImage" as HomeImage from team t,match m where t."TeamID"=m."HomeResTeamID" and m."MatchID"=m1."MatchID"),

(select t."TeamName" as AwayName from team t,match m where t."TeamID"=m."AwayResTeamID" and m."MatchID"=m1."MatchID"),
(select t."TeamImage" as AwayImage from team t,match m where t."TeamID"=m."AwayResTeamID" and m."MatchID"=m1."MatchID")

from match m1
inner join result r using("MatchID")
inner JOIN stadium s using("StadiumID");