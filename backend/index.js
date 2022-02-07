import express from "express";
import { Low, JSONFile } from "lowdb";

const app = express();
app.use(express.json());
const adapter = new JSONFile("leaderboard.json");
const leaderboard = new Low(adapter);
app.get("/", async (req, res) => {
  await leaderboard.read();

  return res.send(topTen(leaderboard.data.scores));
});
app.post("/", async (req, res) => {
  await leaderboard.read();
  leaderboard.data.scores.push(req.body);
  leaderboard.write()
  res.sendStatus(200)
});
app.listen(1234);
const topTen = (scores) => {
  let topScores = scores.slice();
  while (topScores.length > 10) {
    let lowestScore = 0;
    for (let i = 0; i < topScores.length; i++) {
      if (topScores[i][0] < topScores[lowestScore][0]) {
        lowestScore = i;
      }
    }
    topScores.splice(lowestScore, 1);
  }
  return topScores;
};
