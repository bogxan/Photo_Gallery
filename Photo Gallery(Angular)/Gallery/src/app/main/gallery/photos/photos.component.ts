import {Component} from "@angular/core";
import {PhotosService} from "./photos.service";

@Component({
  selector: 'photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.scss']
})
export class PhotosComponent{
  constructor(readonly photosService: PhotosService) {

  }
}
