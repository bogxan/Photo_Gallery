import {Injectable} from "@angular/core"
import {Photo} from "../../../photo.interface";
import {GalleryApiService} from "../../../api/gallery/gallery-api.service";
import {switchMap} from "rxjs/operators";
import {Observable, of} from "rxjs";
import {ApiPhoto} from "../../../api/gallery/api-interfaces";

@Injectable()
export class PhotosService{
  photos$: Observable<Photo[]>;

  constructor(
    private readonly galleryApiService: GalleryApiService
  ) {
    this.photos$ = this.galleryApiService.getAllPhotos().pipe(
      switchMap(photos => {
        let newPhotos: Photo[] = this.getNewPhotos(photos);
        let res$: Observable<Photo[]> = of(newPhotos);
        return res$;
      })
    );
  }

  getPhotoById(id: number): Observable<Photo>{
    return this.galleryApiService.getPhotoById(id).pipe(
      switchMap(ph => {
        let date: string = ph.creationDate.slice(0, 10);
        let newPhoto = {
          id: ph.id,
          name: ph.name,
          description: ph.description,
          rating: ph.rating,
          author: ph.author,
          url: ph.url,
          feedbacks: ph.feedbacks,
          creationDate: new Date(Number(date.slice(0, 4)), Number(date.slice(5, 7)) - 1, Number(date.slice(8, 10)))
        };
        let res$: Observable<Photo> = of(newPhoto);
        return res$;
      })
    );
  }

  addPhoto(photo: Photo){
    this.photos$ = this.galleryApiService.createNewPhoto(photo).pipe(
      switchMap(photos => {
        let newPhotos: Photo[] = this.getNewPhotos(photos);
        let res$: Observable<Photo[]> = of(newPhotos);
        return res$;
      })
    );
  }

  editPhoto(photo: Photo){
    this.photos$ = this.galleryApiService.editPhoto(photo).pipe(
      switchMap(photos => {
        let newPhotos: Photo[] = this.getNewPhotos(photos);
        let res$: Observable<Photo[]> = of(newPhotos);
        return res$;
      })
    );
  }

  removePhoto(id: number){
    this.photos$ = this.galleryApiService.removePhoto(id).pipe(
      switchMap(photos => {
        let newPhotos: Photo[] = this.getNewPhotos(photos);
        let res$: Observable<Photo[]> = of(newPhotos);
        return res$;
      })
    );
  }

  addFeedback(id: number, feedback: string){
    this.photos$ = this.galleryApiService.addFeedback(id, feedback).pipe(
      switchMap(photos => {
        let newPhotos: Photo[] = this.getNewPhotos(photos);
        let res$: Observable<Photo[]> = of(newPhotos);
        return res$;
      })
    );
  }

  getFeedbacks(id: number): Observable<string[]>{
    return this.galleryApiService.getFeedbacks(id);
  }

  removeFeedback(id: number, feedback: string){
    this.photos$ = this.galleryApiService.removeFeedback(id, feedback).pipe(
      switchMap(photos => {
        let newPhotos: Photo[] = this.getNewPhotos(photos);
        let res$: Observable<Photo[]> = of(newPhotos);
        return res$;
      })
    )
  }

  getNewPhotos(photos: ApiPhoto[]): Photo[]{
    let newPhotos: Photo[] = [];
    if(photos.length > 0){
      photos.forEach(photo => {
        let date: string = photo.creationDate.slice(0, 10);
        newPhotos.push({
          id: photo.id,
          name: photo.name,
          description: photo.description,
          rating: photo.rating,
          author: photo.author,
          url: photo.url,
          feedbacks: photo.feedbacks,
          creationDate: new Date(Number(date.slice(0, 4)), Number(date.slice(5, 7)) - 1, Number(date.slice(8, 10)))
        });
      });
    }
    return newPhotos;
  }
}
