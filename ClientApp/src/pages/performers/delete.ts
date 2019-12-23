import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {PerformerService} from "../../services/performers-service";
import {IPerformer} from "../../interfaces/IPerformer";

export var log = LogManager.getLogger('Performer.Delete');

@autoinject
export class Delete {

  private performer: IPerformer;

  constructor(
    private router: Router,
    private performerService: PerformerService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.performerService.delete(this.performer.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("PerformersIndex");
      } else {
        log.debug('response', response);
      }
    });
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');

  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);
    this.performerService.fetch(params.id).then(
      performer => {
        log.debug('performer', performer);
        this.performer = performer;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
