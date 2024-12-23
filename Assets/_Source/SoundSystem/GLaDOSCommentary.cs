using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem{
    
    public class GLaDOSCommentary : MonoBehaviour
    {
        private List<AudioClip> vo;
        private AudioSource sfxSource;
        private System.Random rnd;

        public void Construct(List<AudioClip> vo, AudioSource sfxSource, System.Random rnd)
        {
            this.vo = vo;
            this.sfxSource = sfxSource;
            this.rnd = rnd;
        }
        private IEnumerator IntroductionCoroutine()
        {
            sfxSource.PlayOneShot(vo[0]);
            yield return new WaitForSeconds(vo[0].length);
            sfxSource.PlayOneShot(vo[1]);
            yield return new WaitForSeconds(vo[1].length);
            sfxSource.PlayOneShot(vo[2]);
            yield return new WaitForSeconds(vo[2].length);
        }
        private IEnumerator RandomQuoteCoroutine()
        {
            yield return new WaitForSecondsRealtime(rnd.Next(5,21));
            AudioClip clip = vo[rnd.Next(3,vo.Count)];
            sfxSource.PlayOneShot(clip);
            yield return new WaitForSecondsRealtime(clip.length);
            StartCoroutine(RandomQuoteCoroutine());
        }
        public void IntroductionQuote()
        {
            StartCoroutine(IntroductionCoroutine());
        }
        public void StartRandomQuotes()
        {
            StartCoroutine(RandomQuoteCoroutine());
        }
        public void StopQuotes()
        {
            StopAllCoroutines();
        }
    }
    
}
