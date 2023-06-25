import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from '../models/post';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  basePath = "https://localhost:7228"

  constructor(private httpClient: HttpClient) { }
  getPosts(): Observable<Post[]> {
    let url = "/GetPosts"
    return this.httpClient.get<Post[]>(this.basePath+url)
  }
  getPostsByUserId(id: number): Observable<Post[]> {
    let url = "/GetPostsByUserId"    
    const params = new HttpParams().set('id', id)
    return this.httpClient.get<Post[]>(this.basePath+url,{params})
  }
  createPost(post: Post): Observable<Post> {
    let url= "/CreatePost"
    return this.httpClient.post<Post>(this.basePath+url, post).pipe()
  }
  deletePost(id: number): Observable<any> {
    let url= "/DeletePost"
    const params = new HttpParams().set('id', id)
    return this.httpClient.delete<any>(this.basePath+url, {params}).pipe()
  }
  // login(userName: string, password: string){
  //   let url= "/Login"
  //   const params = new HttpParams().set('username', userName).set('password', password)
  //   return this.httpClient.post<ResponseDto>(this.basePath+url, null, {params}).pipe()
  // }
}
