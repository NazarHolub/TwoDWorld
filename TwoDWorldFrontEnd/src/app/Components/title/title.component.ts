import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Title } from 'src/app/Models/title';
import { TitleService } from 'src/app/services/title.service';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.css']
})
export class TitleComponent implements OnInit {

  title: Title;
  id: string;
  constructor(private route: ActivatedRoute,
              private service: TitleService) { }

  ngOnInit() {
    this.id=this.route.snapshot.paramMap.get("id");
    
    this.service.getTitle(Number(this.id)).subscribe((response)=>{

      if(response.isSuccessFull){
        this.title = response.result;
      }
      else{
        alert(response.message);
      }
    })
  }

}
