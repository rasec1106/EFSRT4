
using System;
using Microsoft.AspNetCore.Mvc;
using ApiComment.Repository;
using ApiComment.Dtos;

namespace ApiComment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentContoller : ControllerBase
    {
        private ICommentRespository commentRespository;
        private ResponseDto responseDto;


        public CommentContoller(ICommentRespository commentRespository)
        {
            this.commentRespository = commentRespository;
            this.responseDto = new ResponseDto();
        }

        [HttpGet]
        [Route("/GetAllComments")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<CommentDto> CommentDtos = await commentRespository.GetComments();
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = CommentDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }
        [HttpGet]
        [Route("/GetCommentById/{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                CommentDto commentDto = await commentRespository.GetCommentById(id);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = commentDto;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }



        [HttpPost]
        [Route("/CreateComment")]
        public async Task<object> Post(CommentDto commentDto)
        {
            try
            {
                CommentDto result = await commentRespository.CreateComment(commentDto);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";

            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }
        [HttpPut]
        [Route("/UpdateComment")]
        public async Task<object> Put(CommentDto commentDto)
        {
            try
            {
                CommentDto result = await commentRespository.UpdateComment(commentDto);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;

            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }
        [HttpDelete]
        [Route("/DeleteComment")]
        public async Task<object> Delete(int id)
        {
            try
            {

                bool result = await commentRespository.DeleteComment(id);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;

        }
        [HttpGet]
        [Route("/GetCommentsByPostId")]
        public async Task<object> GetByPostId(int postId)
        {
            try
            {
                IEnumerable<CommentDto> CommentDtos = await commentRespository.GetCommentsByPostId(postId);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = CommentDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [HttpGet]
        [Route("/GetCommentsByUserId")]
        public async Task<object> GetByUserId(int userId)
        {
            try
            {
                IEnumerable<CommentDto> CommentDtos = await commentRespository.GetCommentsByUserId(userId);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = CommentDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

    }
}
