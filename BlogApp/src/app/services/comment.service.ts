import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { CommentResponse } from '../models/comment-response';
import { Comment } from '../models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  basePath = "https://localhost:7272"

  constructor(private httpClient: HttpClient) { }
  getCommentsByPostId(postId: number): Observable<any> {
    let url = `/GetCommentsByPostId?postId=${postId}`
    return this.httpClient.get<CommentResponse>(this.basePath+url).pipe(map(res=>res.result))
  }

  getCommentsByUserId(userId: number): Observable<any> {
    let url = `/GetCommentsByUserId?userId=${userId}`
    return this.httpClient.get<CommentResponse>(this.basePath+url).pipe(map(res=>res.result))
  }

  createComment(comment: Comment): Observable<Comment>{
    let url = "/CreateComment"
    return this.httpClient.post<Comment>(this.basePath+url,comment)
  }

}
