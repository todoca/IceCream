import { Component } from '@angular/core';
import { IceCream } from './models/ice-cream';
import { IceCreamService } from './services/ice-cream.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Ice Cream App With Love';
  iceCreams: IceCream[] = [];

  constructor(private iceCreamService: IceCreamService) {}

  ngOnInit(): void {
    this.iceCreams = this.iceCreamService.getIceCreams();
    console.log(this.iceCreams);
  }
}
