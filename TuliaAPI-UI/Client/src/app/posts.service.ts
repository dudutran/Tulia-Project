import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Post } from './models/post';
import { Observable } from 'rxjs';
import { Comment } from './models/comment';
import { Like } from './models/like';
import { PostDetail } from './models/postdetail';
import { baseUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  private postUrl = `${baseUrl}Post`;
  private pUrl = `${baseUrl}`;
  private commentUrl = `${baseUrl}Comment`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private router: Router,
  ) { }

  getAllPosts(post: Post) {
    return this.http.get<Post[]>(`${this.postUrl}/all`);
  }

  getPostById(id: number): Observable<PostDetail> {
    const url = `${this.postUrl}/postwithcomments/${id}`;
    return this.http.get<PostDetail>(url);
  }

  getComment(id: number): Observable<Comment> {
    const url = `${this.commentUrl}/post/${id}`;
    return this.http.get<Comment>(url);
  }

  createPost(post: Post): Observable<Post> {
    return this.http.post<Post>(`${this.postUrl}/create`, post, this.httpOptions).pipe
      (catchError(this.handleError1));
  }

  createComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>(`${this.commentUrl}/create`, comment, this.httpOptions).pipe
      (catchError(this.handleError1));
  }

  addLike(like: Like): Observable<Like> {
    return this.http.post<Like>(`${this.postUrl}/like`, like, this.httpOptions).pipe
      (catchError(this.handleError1));
  }

  handleError1(error: HttpErrorResponse) {
    return throwError(error.error);
  }

  deletePost(id: number): Observable<Post> {
    const url = `${this.pUrl}/delete/${id}`;
    return this.http.delete<Post>(url, this.httpOptions).pipe(

      catchError(this.handleError1));
  }
}
