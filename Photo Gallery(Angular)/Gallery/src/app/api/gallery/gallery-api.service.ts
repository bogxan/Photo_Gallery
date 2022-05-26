import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {publishReplay, refCount} from "rxjs/operators";
import {ApiPhoto} from "./api-interfaces";
import {Photo} from "../../photo.interface";
import {BrowserLocalStorage} from "../../shared/storage/local-storage";
import {environment} from "../../../environments/environment";

@Injectable()
export class GalleryApiService{
  readonly options = {
    headers: {
      'Authorization': `Bearer ${this.browserLocalStorage.getItem('accessToken')}`
    }
  };
  constructor(
    private readonly httpClient: HttpClient,
    private readonly browserLocalStorage: BrowserLocalStorage
  ) {
  }

  getAllPhotos(): Observable<ApiPhoto[]>{
    return this.httpClient.get<ApiPhoto[]>(
      [
        environment.apiUrl,
        'Photos'
      ].join('/'),
      this.options
    ).pipe(
      publishReplay(1),
      refCount()
    );
  }

  createNewPhoto(photo: Photo): Observable<ApiPhoto[]>{
    return this.httpClient.post<ApiPhoto[]>(
      [
        environment.apiUrl,
        'Photos'
      ].join('/'),
      photo,
      this.options
    ).pipe(
      publishReplay(1),
      refCount()
    );
  }

  removePhoto(id: number) : Observable<ApiPhoto[]>{
    return this.httpClient.delete<ApiPhoto[]>(
      [
        environment.apiUrl,
        'Photos',
        id
      ].join('/'),
      this.options
    ).pipe(
      publishReplay(1),
      refCount()
    );
  }

  getPhotoById(id: number): Observable<ApiPhoto>{
    return this.httpClient.get<ApiPhoto>(
      [
        environment.apiUrl,
        'Photos',
        id
      ].join('/'),
      this.options
    ).pipe(
      publishReplay(1),
      refCount()
    );
  }

  editPhoto(photo: Photo) : Observable<ApiPhoto[]>{
    return this.httpClient.put<ApiPhoto[]>(
      [
        environment.apiUrl,
        'Photos'
      ].join('/'),
      photo,
      this.options
    ).pipe(
      publishReplay(1),
      refCount()
    );
  }

  addFeedback(id: number, feedback: string) : Observable<ApiPhoto[]>{
    return this.httpClient.post<ApiPhoto[]>(
      [
        environment.apiUrl,
        'Feedbacks'
      ].join('/'),
      {
        value: feedback,
        photoId: id
      },
      this.options
    ).pipe(
      publishReplay(1),
      refCount()
    );
  }

  getFeedbacks(id: number) : Observable<string[]>{
    return this.httpClient.get<string[]>(
      [
        environment.apiUrl,
        'Feedbacks',
      ].join('/') + `?photoId=${id}`,
      this.options
    ).pipe(
      publishReplay(1),
      refCount()
    );
  }

  removeFeedback(id: number, feedback: string): Observable<ApiPhoto[]>{
    return this.httpClient.delete<ApiPhoto[]>(
      [
        environment.apiUrl,
        'Feedbacks'
      ].join('/') + `?photoId=${id}&feedback=${feedback}`,
      this.options
    ).pipe(
      publishReplay(1),
      refCount()
    );
  }
}
