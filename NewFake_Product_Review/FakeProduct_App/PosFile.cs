using edu.stanford.nlp.tagger.maxent;
using java.io;
using java.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FakeProduct_App
{
    public static class PosFile
    {
        static FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities();
        public static string TraggerMain(string text)
        {
            String taggedSentence = "";
            var jarRoot = @"E:\Project\NewFake_Product_Review\FakeProduct_App\bin";
            //var modelsDirectory = jarRoot + @"\models";

            // Loading POS Tagger
            var tagger = new MaxentTagger(jarRoot + @"\english-caseless-left3words-distsim.tagger");

            // Text for tagging


            var sentences = MaxentTagger.tokenizeText(new StringReader(text)).toArray();
            foreach (ArrayList sentence in sentences)
            {
                taggedSentence += tagger.tagSentence(sentence).ToString();
            }
            return taggedSentence;
        }
        public static Double postagger(string objPara)
        {
            double pos, neg;
            List<string> lstJJ = new List<string>();
            //List<string> lstRB = new List<string>();
            List<string> lstNNP = new List<string>();
            List<string> lstRB = new List<string>();
            string str = null;
            string[] strArr = null;

            str = objPara;
            char[] splitchar = { '.' };
            strArr = str.Split(splitchar);

            Double TotalScore = 0.0;
            for (int i = 0; i <= strArr.Length - 1; i++)
            {

                string currSentance = strArr[i].ToString();
                string[] objWord = currSentance.Split(' ');
                for (int j = 0; j < objWord.Length; j++)
                {
                    int startindex = objWord[j].IndexOf("/");
                    if (startindex < 0) { startindex = 0; }
                    int lastindex = objWord[j].Length;
                    string NewPos = objWord[j].Remove(0, startindex);
                    string NewPos1 = NewPos.TrimEnd(',', ']');

                    string NewWord = objWord[j].Substring(0, startindex);

                    switch (NewPos1)
                    {
                        case "/JJ":
                            {
                                lstJJ.Add(NewWord);
                            }
                            break;
                        case "/NNP":
                            {
                                lstNNP.Add(NewWord);
                            }
                            break;
                        case "/NN":
                            {
                                lstNNP.Add(NewWord);
                            }
                            break;
                        case "/RB":
                            {
                                lstRB.Add(NewWord);
                            }
                            break;
                        default:
                            { break; }
                    }
                }

                int jjCount = lstJJ.Count;
                for (int k = 0; k < jjCount; k++)
                {
                    if (lstJJ.Count > lstNNP.Count)
                    {
                        lstJJ.RemoveAt(lstJJ.Count - 1);
                    }
                }
                int nnCount = lstNNP.Count;
                for (int l = 0; l < nnCount; l++)
                {
                    if (lstNNP.Count > lstJJ.Count)
                    {
                        lstNNP.RemoveAt(lstNNP.Count - 1);
                    }
                }
                Double TotalRBSore = 0.0;
                Double TotalJJScore = 0.0;
                Double TotalRScore = 0.0;
                Double TotalJScore = 0.0;


                pos = 0.0;
                neg = 0.0;

                for (int m = 0; m < lstRB.Count; m++)
                {
                    pos = 0.0;
                    neg = 0.0;
                    TotalRBSore = 0.0;


                    string CN = ConfigurationManager.ConnectionStrings["FakeProductReviewDbEntities"].ConnectionString;

                    using (SqlConnection cn = new SqlConnection(dbContext.Database.Connection.ConnectionString))
                    {
                        cn.Open();
                        string query = "select max(PosScore)as PosScore, Max(NegScore) as NegScore, SynsetTerms from SentiWordNet group by SynsetTerms having SynsetTerms=@SynsetTerms";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@SynsetTerms", lstRB[m].ToString());
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            pos = Convert.ToDouble(dt.Rows[0]["PosScore"]);
                            neg = Convert.ToDouble(dt.Rows[0]["NegScore"]);
                        }
                        if (pos > neg)
                        {
                            TotalRBSore += pos;
                        }
                        else
                        {
                            neg = neg * -1;
                            TotalRBSore += neg;
                        }
                        TotalRScore += TotalRBSore;
                    }
                }

                for (int m = 0; m < lstNNP.Count; m++)
                {
                    pos = 0.0;
                    neg = 0.0;
                    TotalJJScore = 0.0;
                    string CN = ConfigurationManager.ConnectionStrings["FakeProductReviewDbEntities"].ConnectionString;
                    using (SqlConnection cn = new SqlConnection(dbContext.Database.Connection.ConnectionString))
                    {
                        cn.Open();
                        string query = "select max(PosScore)as PosScore, Max(NegScore) as NegScore, SynsetTerms from SentiWordNet group by SynsetTerms having SynsetTerms=@SynsetTerms";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@SynsetTerms", lstJJ[m].ToString());
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            pos = Convert.ToDouble(dt.Rows[0]["PosScore"]);
                            neg = Convert.ToDouble(dt.Rows[0]["NegScore"]);
                        }
                        if (pos > neg)
                        {
                            TotalJJScore += pos;
                        }
                        else
                        {
                            neg = neg * -1;
                            TotalJJScore += neg;
                        }
                        TotalJScore += TotalJJScore;
                    }
                }

                if (TotalRScore != 0)
                {
                    TotalScore += (TotalRScore * TotalJScore) == 0 ? 1 : (TotalRScore * TotalJScore);
                }
                else
                {
                    TotalScore += TotalJScore;
                }
                lstJJ.Clear();
                lstNNP.Clear();
                lstRB.Clear();
            }
            // HttpContext.Current.Session["Score"] = TotalScore;
            return TotalScore;
        }
    }
}