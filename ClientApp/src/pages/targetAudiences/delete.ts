import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {TargetAudienceService} from "../../services/targetaudiences-service";
import {ITargetAudience} from "../../interfaces/ITargetAudience";

export var log = LogManager.getLogger('TargetAudience.Delete');

@autoinject
export class Delete {

  private targetAudience: ITargetAudience;

  constructor(
    private router: Router,
    private targetAudienceService: TargetAudienceService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.targetAudienceService.delete(this.targetAudience.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("TargetAudiencesIndex");
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
    this.targetAudienceService.fetch(params.id).then(
      targetAudience => {
        log.debug('targetaudience', targetAudience);
        this.targetAudience = targetAudience;
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
