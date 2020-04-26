﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using serverChallengeMe.Models;
using Newtonsoft.Json.Linq;

namespace serverChallengeMe.Controllers
{
    public class ChallengeController : ApiController
    {
        // GET api/Challenge
        public DataTable Get()
        {
            Challenge c = new Challenge();
            return c.getChallenge();
        }

        // GET api/Challenge?studentID={studentID}
        public DataTable getChallengesWithoutStudentChallenges(int studentID)
        {
            Challenge c = new Challenge();
            return c.getChallengesWithoutStudentChallenges(studentID);
        }

        // GET api/Challenge?challengeName={challengeName}
        public DataTable getChallengeByName(string challengeName)
        {
            Challenge c = new Challenge();
            return c.getChallengeByName(challengeName);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Challenge
        public DataTable Post([FromBody] JObject data)
        {
            Challenge c = new Challenge();
            return c.postChallenge(data);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}