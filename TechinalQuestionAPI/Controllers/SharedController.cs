using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalQuestionAPI.Context;
using TechnicalQuestionAPI.Interfaces;
using TechnicalQuestionAPI.DTO2.UsersTwo;
using TechnicalQuestionAPI.DTO.Users;
using TechnicalQuestionAPI.Helper;
using TechnicalQuestionAPI.DTO.Skills;
using TechnicalQuestionAPI.DTO.Authantication;
using TechnicalQuestionAPI.Models;
using TechnicalQuestionAPI.DTO.JobTitles;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace TechnicalQuestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase, ISharedInterface
    {
        private readonly TechnicalQuestionDbContext _context;
        public SharedController(TechnicalQuestionDbContext context)
        {
            _context = context;
        }


        #region JobTitle

        [HttpGet]
        [Route("GetJobTitleById/{Id}")]
        public async Task<JobTitle> GetJobTitleByIdAsync([FromRoute] int Id)
        {
            var result = await _context.JobTitles.FindAsync(Id);
            return result;
        }

        //[HttpGet]
        //[Route("GetJobTitles")]
        //public async Task<List<JobTitleCardDTO>> GetJobTitlesAsync()
        //{
        //    var jobTitles = await _context.JobTitles.ToListAsync();
        //    var result = from j in jobTitles
        //                 select new JobTitleCardDTO
        //                 {
        //                     Id=j.JobTitleId,
        //                     Name=j.Name,
        //                     Description=j.Description,
        //                     SalaryScale=(j.MinSalary+j.MaxSalary)/2
        //                 };
        //    return (result.ToList());
        //}

        [HttpGet]
        [Route("[action]")]//**
        public async Task<List<JobTitleCardDTO>> SearchJobTitleAsync(string? name,
            string? requirement, int? level)
        {
            var jobTitles = await _context.JobTitles.ToListAsync();
            if (name != null)
                jobTitles = jobTitles.Where(x => x.Name.Contains(name)).ToList();
            if (requirement != null)
                jobTitles = jobTitles.Where(x => x.Requirements.Contains(requirement)).ToList();
            if (level != null)
                jobTitles = jobTitles.Where(x => x.Level == level).ToList();
            var result = from j in jobTitles
                             //where j.Name.Contains(name) - method 2
                         select new JobTitleCardDTO
                         {
                             Id = j.JobTitleId,
                             Name = j.Name,
                             Description = j.Description,
                             SalaryScale = (j.MinSalary + j.MaxSalary) / 2
                         };
            return (result.ToList());
        }
        #endregion

        #region UserProfile
        [HttpGet]
        [Route("[action]/{userType}")]
        public async Task<List<UserCardDTO>> GetAllUsersByTypeAsync([FromRoute] string userType)
        {
            var Users = await _context.Users.Where(x => x.UserType.Equals(userType)).ToListAsync();
            var result = from user in Users
                         select new UserCardDTO
                         {
                             UserId = user.UserId,
                             FullName = user.FullName,
                             Address = user.Address,
                             Age = user.Age,
                             Bio = user.Bio,
                             Email = user.Email,
                             PersonalPhotoPath = user.PersonalPhotoPath,
                             PhoneNumber = user.PhoneNumber,
                             Specification = user.Specification,
                             UserType = user.UserType,

                         };
            return result.ToList();
        }
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<User> GetUserByIdAsync([FromRoute] int Id)
        {
            var Users = await _context.Users.FindAsync(Id);

            return Users;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<List<UserCardDTO>> SearchUsersAsync(string? name, string? userType, string? jobTitle
            , string? nationality, string? phone)
        {
            var Users = await _context.Users.ToListAsync();
            if (name != null)
                Users = Users.Where(x => x.FullName.Contains(name)).ToList();
            if (userType != null)
                Users = Users.Where(x => x.UserType.Equals(userType)).ToList();
            if (jobTitle != null)
                Users = Users.Where(x => x.Specification.Contains(jobTitle)).ToList();
            //if (nationality != null)
            //    Users = Users.Where(x => x.na.Contains(name)).ToList();
            if (phone != null)
                Users = Users.Where(x => x.FullName.Contains(phone)).ToList();
            var result = from user in Users
                         select new UserCardDTO
                         {
                             UserId = user.UserId,
                             FullName = user.FullName,
                             Address = user.Address,
                             Age = user.Age,
                             Bio = user.Bio,
                             Email = user.Email,
                             PersonalPhotoPath = user.PersonalPhotoPath,
                             PhoneNumber = user.PhoneNumber,
                             Specification = user.Specification,
                             UserType = user.UserType,

                         };
            return result.ToList();
        }
        [HttpGet]
        [Route("UserProfile/{Id}")]
        public async Task<UserProfileDTO> GetUserProfileById(int Id)
        {
            if (await _context.Users.AnyAsync(x => x.UserId == Id))
            {
                //user exisit
                //var person = await _context.Users.Where(x => x.UserId == Id).Include(x=>x.Subsucription).SingleAsync();
                //var eduHistory = await _context.EductionHistorys.Where(x => x.User.UserId == Id).ToListAsync();
                //var expirense = await _context.Expierinces.Where(x => x.User.UserId == Id).ToListAsync();
                //var exam = await _context.Exams.Where(x => x.User.UserId == Id).ToListAsync();
                //var subs = await _context.Subsucriptions.ToListAsync();
                //method 1 
                //var results = from p in person
                //              join e in eduHistory
                //              on p.UserId equals e.User.UserId
                //              join ex in expirense
                //              on p.UserId equals ex.User.UserId
                //              join exm in exam
                //              on p.UserId equals exm.User.UserId
                //              select new
                //              {
                //                  Person = p,
                //                  Edu = e,
                //                  Exam= ex,
                //                  Experinces=exm
                //              };
                //return results;
                //------------------------------------------------
                //method 2 
                //var results = from p in person
                //              join e in eduHistory
                //               on p.UserId equals e.User.UserId
                //              join ex in expirense
                //              on p.UserId equals ex.User.UserId
                //              join exm in exam
                //              on p.UserId equals exm.User.UserId
                //              join s in subs
                //               on p.Subsucription.SubsucriptionId equals s.SubsucriptionId
                //              select p;
                //return results;
                //method 3 
                //var results = from p in person
                //              join e in eduHistory
                //               on p.UserId equals e.User.UserId
                //              join ex in expirense
                //              on p.UserId equals ex.User.UserId
                //              join exm in exam
                //              on p.UserId equals exm.User.UserId
                //              join s in subs 
                //              on   p.Subsucription.SubsucriptionId 
                //              equals s.SubsucriptionId
                //              select new UserProfileDTO
                //              {
                //                  UserId = p.UserId,
                //                  FullName = p.FullName,
                //                  Age = p.Age,
                //                  Specification = p.Specification,
                //                  Email = p.Email,
                //                  NationlityId = p.NationlityId,
                //                  UserType = p.UserType,
                //                  Subsucription=s,
                //              };
                //return results.DistinctBy(x => x.UserId).ToList();

                //method 4 - With Basic Join 
                //var perosnSubscuciption = from s in subs
                //                          join p in person
                //                          on s.SubsucriptionId equals p.Subsucription.SubsucriptionId
                //                          select p;
                //User user = perosnSubscuciption.FirstOrDefault();   
                //var results = new
                //{
                //    Perons = user,
                //    EducationHistories = eduHistory,
                //    Experinces = expirense,
                //    Exams = exam,
                //    Subsucribition = user.Subsucription
                //};

                //return results;
                //method 4 - With Include
                //var results = new
                //{
                //    Perons = person,
                //    EducationHistories = eduHistory,
                //    Experinces = expirense,
                //    Exams = exam
                //    //Subsucribition = person.Subsucription
                //};

                //return results;

                //method 5 -just using Include
                var personPrfofile = await _context.Users.Where(x => x.UserId == Id)
                    .Include(x => x.Subsucription)
                    .Include(x => x.EductionHistories)
                    .Include(x => x.Expierinces)
                    .Include(x => x.Exams)
                    .Include(x => x.UserSkills)
                    .ThenInclude(b => b.Skill)
                    .Include(x => x.UserAssignments)
                    .ThenInclude(x => x.Assignment)
                    .SingleAsync();
                //return personPrfofile;
                UserProfileDTO userProfileDTO = new UserProfileDTO();
                userProfileDTO.UserId = personPrfofile.UserId;
                userProfileDTO.FullName = personPrfofile.FullName;
                userProfileDTO.Age = personPrfofile.Age;
                userProfileDTO.Specification = personPrfofile.Specification;
                userProfileDTO.Email = personPrfofile.Email;
                userProfileDTO.NationlityId = personPrfofile.NationlityId;
                userProfileDTO.UserType = personPrfofile.UserType;
                userProfileDTO.Bio = personPrfofile.Bio;
                userProfileDTO.PersonalPhotoPath = personPrfofile.PersonalPhotoPath;
                userProfileDTO.Address = personPrfofile.Address;
                userProfileDTO.PhoneNumber = personPrfofile.PhoneNumber;
                userProfileDTO.Nationality = personPrfofile.Nationality;
                userProfileDTO.Exams = MappingHelper.ExamDtoMapper(personPrfofile.Exams.ToList());
                userProfileDTO.Experinces = MappingHelper.ExperienceDTOMapper(personPrfofile.Expierinces.ToList());
                userProfileDTO.EducationHistories = MappingHelper.EducationHistoryMapper(personPrfofile.EductionHistories.ToList());
                userProfileDTO.SubsucriptionName = personPrfofile.Subsucription.Title;
                return userProfileDTO;
                //string response = JsonSerializer.Serialize(personPrfofile);
                //return response;
            }
            throw new Exception("User Dose not Exisit");
        }
        #endregion

        #region Skills
        [HttpGet]
        [Route("GetSkills")]
        public async Task<List<SkillsCardDTO>> GetAllSkillsAsync()
        {
            var Skills = await _context.Skills.ToListAsync();
            var result = from Skill in Skills
                         select new SkillsCardDTO
                         {
                             Title = Skill.Title,
                             Description = Skill.Description,
                             Rate = Skill.Rate,
                             SkillsId = Skill.SkillsId
                         };
            return (result.ToList());
        }
        #endregion

        #region Authatication
        [HttpPost]
        [Route("CreateNewAccount")]
        public async Task Register(RegisterDTO dto)
        {
            User jobSeeker = new User();
            jobSeeker.FullName = dto.FullName;
            jobSeeker.Age = dto.Age;
            jobSeeker.Specification = dto.Specification;
            jobSeeker.Email = dto.Email;
            jobSeeker.Password = dto.Password;
            jobSeeker.NationlityId = dto.NationlityId;
            jobSeeker.Nationality = dto.Nationality;
            jobSeeker.PhoneNumber = dto.PhoneNumber;
            jobSeeker.UserType = "JobSeeker";
            jobSeeker.IsActive = true;
            jobSeeker.IsLoggedIn = false;
            jobSeeker.Address = "";
            jobSeeker.Subsucription = await _context.Subscriptions.SingleAsync(x => x.SubsucriptionId == 1);
            await _context.AddAsync(jobSeeker);
            await _context.SaveChangesAsync();

        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                throw new Exception("Email Is Required");
            if (string.IsNullOrEmpty(dto.Password))
                throw new Exception("Password Is Required");
            var user = _context.Users.SingleOrDefault(x =>
            x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password));
            if (user != null)
            {
                if (!user.IsLoggedIn)
                {
                    user.IsLoggedIn = true;
                    //Generate Access Key
                    //1- Generate Random Value and Store it in data base
                    //user.AccessKey = Guid.NewGuid().ToString(); 
                    //user.AccesskeyExpireDate= DateTime.Now.AddMinutes(5);
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    //2-JWT 
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.UTF8.GetBytes("LongSecrectStringForModulekodestartppopopopsdfjnshbvhueFGDKJSFBYJDSAGVYKDSGKFUYDGASYGFskc vhHJVCBYHVSKDGHASVBCL");
                    var tokenDescriptior = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("UserId",user.UserId.ToString()),
                        new Claim("Name",user.FullName)
                        }),
                        Expires = DateTime.Now.AddHours(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                        , SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptior);//encoding
                    string finalToken = tokenHandler.WriteToken(token);
                    return Ok(/*user.AccessKey*/finalToken);
                }

                else
                {
                    user.IsLoggedIn = false;
                    _context.Update(user);
                    await _context.SaveChangesAsync();


                    return Ok("Youre Session Has been Closed Please Login in Again");
                }
            }
            else
            {
                return Unauthorized("Either Email or Password is Incorrect");
            }
        }
        [HttpPut]
        [Route("Logout")]
        public async Task Logout(int UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user != null)
            {
                user.IsLoggedIn = false;
                user.AccessKey = "";
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }
        [HttpPut]
        [Route("ResetPassword")]
        public async Task ResetPassword(ResetPasswordDTO dTO)
        {
            //check if the email/nationality/newpassword not equal null
            if (dTO.Email != null && dTO.NationlityId != null && dTO.NewPassword != null)
            {
                //find the user
                var user = await _context.Users.Where(x => x.Email == dTO.Email && x.NationlityId == dTO.NationlityId).SingleAsync();
                if (user != null)
                {
                    //update the password
                    user.IsLoggedIn = false;
                    _context.Update(user);
                    //savechanges
                    await _context.SaveChangesAsync();
                }
            }
            throw new NotImplementedException("Please Fill All Information");
        }
        #endregion

    }
}
