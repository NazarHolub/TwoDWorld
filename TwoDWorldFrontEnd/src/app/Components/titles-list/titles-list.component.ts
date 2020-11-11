import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { ApiCollectionResult } from 'src/app/Models/apiResult';
import { Title } from 'src/app/Models/title';
import { TitleService } from 'src/app/services/title.service';

@Component({
  selector: 'app-titles-list',
  templateUrl: './titles-list.component.html',
  styleUrls: ['./titles-list.component.css']
})
export class TitlesListComponent implements OnInit {

  titles: Array<Title>;

  constructor(private service: TitleService,
              private route: Router) { }

  ngOnInit() {
    this.service.getTitles().subscribe((response: ApiCollectionResult)=>{
      if(response.isSuccessFull) {
        this.titles = response.result;
      }
      else if(!response.isSuccessFull){
        alert(response.message)
      }
    });
  }

}
